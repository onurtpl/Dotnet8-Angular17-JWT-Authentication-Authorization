namespace Application.Dtos;
public sealed record AuthResponseDto
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpire { get; set; }

    public ICollection<string> Roles { get; set; } = [];
}
