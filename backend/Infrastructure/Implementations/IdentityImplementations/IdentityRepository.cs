using AutoMapper;
using Application.Contracts.IdentityContracts;
using Application.Dtos;
using Application.Dtos.PaginationDtos;
using Application.Features.Identity.Commands.AssignRole;
using Application.Features.Identity.Commands.CreateRole;
using Application.Features.Identity.Commands.GetUsers;
using Application.Features.Identity.Commands.Login;
using Application.Features.Identity.Commands.RefreshToken;
using Application.Features.Identity.Commands.Register;
using Application.Features.Identity.Commands.ResetPassword;
using Application.Features.Identity.Queries.GetRoles;
using Domain.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Implementations.IdentityImplementations;

public class IdentityRepository : IIdentityRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public IdentityRepository(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        IConfiguration configuration,
        IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _mapper = mapper;
    }



    public async Task<PaginationResponseDto<GetUsersCommandResult>> GetUsersAsync(
        GetUsersCommand request, 
        CancellationToken cancellationToken)
    {
        IQueryable<ApplicationUser> query = _userManager.Users;
        if(!string.IsNullOrEmpty(request.SearchText))
            query = query.Where(e =>
             EF.Functions.Like(e.UserName, $"%{request.SearchText}%") ||
             EF.Functions.Like(e.Email, $"%{request.SearchText}%"));

        var totalCount = await query.CountAsync();
        List<ApplicationUser> users = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        List<GetUsersCommandResult> items = new();
        foreach (var user in users)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            GetUsersCommandResult result = _mapper.Map<GetUsersCommandResult>(user);
            List<string> usersRoles =roles.ToList();
            result.Roles = [.. roles];
            items.Add(result);

        }

        return new PaginationResponseDto<GetUsersCommandResult>()
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,

            IsFirstPage = request.PageNumber == 1,
            IsLastPage = request.PageNumber * request.PageSize >= totalCount
        };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginCommand request, CancellationToken token)
    {
        ApplicationUser? user;
        if ((user = await _userManager.FindByNameAsync(request.User)) is null)
        {
            if ((user = await _userManager.FindByEmailAsync(request.User)) is null)
            {
                throw new Exception("User is not fount!");
            }
        }

        if (!(await _userManager.CheckPasswordAsync(user, request.Password)))
            throw new Exception("Invalid password!");
        return await CreateToken(user);
    }

    public async Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenCommand request, CancellationToken token)
    {
        ApplicationUser? user;
        if ((user = await _userManager
            .Users
            .SingleOrDefaultAsync(u => u.RefreshToken == request.RefreshToken)) is null)
            throw new Exception("Invalid refresh token");
        if (user.RefreshTokenExpireTime < DateTime.UtcNow)
            throw new Exception("Invalid or expired refresh token.");
        return await CreateToken(user);
    }

    public async Task<bool> RegisterAsync(RegisterCommand request, CancellationToken token)
    {
        string password = request.Password!;
        ApplicationUser? user;
        if( (user = await _userManager.FindByNameAsync(request.UserName!)) is not null)
            throw new InvalidOperationException("this username has been taken before");
        if((user = await _userManager.FindByEmailAsync(request.Email!)) is not null)
            throw new InvalidOperationException("this e-mail address has been taken before");
        
        ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(request);
        IdentityResult result = await _userManager.CreateAsync(applicationUser, password);

        if (!result.Succeeded)
            throw new InvalidOperationException("User register error");

        AssignRoleCommand assignRole = new() { Role = "User", User = request.UserName! };
        if (await AssignRoleAsync(assignRole, token))
            return await Task.FromResult(true);
        throw new InvalidOperationException("User register assign role error");
    }

    public async Task<bool> AssignRoleAsync(AssignRoleCommand request, CancellationToken token)
    {
        ApplicationUser? user;
        if((user = await  _userManager.FindByEmailAsync(request.User)) is null)
        {
            if((user = await _userManager.FindByNameAsync(request.User)) is null)
            {
                throw new InvalidOperationException("User not found");
            }
        }

        if (!await _roleManager.RoleExistsAsync(request.Role))
            throw new InvalidOperationException("Role not found");

        IdentityResult result = await _userManager.AddToRoleAsync(user, request.Role);
        if (result.Succeeded)
            return true;
        throw new InvalidOperationException("Assign role error");

    }

    private async Task<AuthResponseDto> CreateToken(ApplicationUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var accessToken = await GenerateAccessToken(user);
        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpireTime = DateTime.UtcNow.AddMinutes(10); 
        await _userManager.UpdateAsync(user);

        return new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            RefreshTokenExpire = DateTime.UtcNow.AddMinutes(10),
            Roles = roles
        };
    }

    private async Task<string> GenerateAccessToken(ApplicationUser user)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        IList<string> roles = await _userManager.GetRolesAsync(user);

        IConfigurationSection JWTSettings = _configuration.GetSection("JWTSettings");
        string securityKey = JWTSettings.GetSection("securitykey").Value!;
        string validAudience = JWTSettings.GetSection("ValidAudience").Value!;
        string validIssuer = JWTSettings.GetSection("ValidIssuer").Value!;
        int expireMinutes = int.Parse(JWTSettings.GetSection("expireMinutes").Value!);


        byte[] key = Encoding.UTF8.GetBytes(securityKey);

        List<Claim> claims = [
            new (JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new (JwtRegisteredClaimNames.Name, user.UserName ?? ""),
            new ("fullname", user.FullName ?? ""),
            new (JwtRegisteredClaimNames.NameId, user.Id ?? ""),
            new (JwtRegisteredClaimNames.Aud, validAudience ),
            new (JwtRegisteredClaimNames.Iss, validIssuer)
        ];
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        SecurityTokenDescriptor desc = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256)
        };

        SecurityToken st = tokenHandler.CreateToken(desc);
        return tokenHandler.WriteToken(st);
    }

    

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public async Task<IEnumerable<GetRolesQueryResult>> GetRolesAsync(GetRolesQuery request, CancellationToken cancellationToken)
    {
        return await _roleManager.Roles.Select(role => 
        new GetRolesQueryResult(role.Id, role.Name!
            )).ToListAsync();
    }

    public async Task<bool> CreateRoleAsync(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        if (await _roleManager.RoleExistsAsync(request.roleName))
            throw new InvalidOperationException("Role is already exist!");

        var role = new ApplicationRole { Name = request.roleName };
        IdentityResult result = await _roleManager.CreateAsync(role);
        if(result.Succeeded)
            return true;
        throw new InvalidOperationException("Create Role Error");
    }

    public async Task<bool> ResetPassword(ResetPasswordCommand request, CancellationToken cancellationToken)
    {

        ApplicationUser? user;

        if ((user = await _userManager.FindByEmailAsync(request.Email)) is null)
            throw new InvalidOperationException("User does not exist with this email");
        IdentityResult result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
        return result.Succeeded ? true : throw new InvalidOperationException("Reset Password Error");
    }
}
