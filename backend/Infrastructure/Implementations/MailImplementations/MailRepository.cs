using Application.Contracts.MailContracts;
using Application.Features.Identity.Commands.ForgotPassword;
using Microsoft.AspNetCore.Identity;
using Domain.Entities.IdentityEntities;

using System.Net;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;

namespace Infrastructure.Implementations.MailImplementations;

public class MailRepository : IMailRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;

    public MailRepository(
        UserManager<ApplicationUser> userManager, 
        IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<bool> ForgotPasswordViaSMTP(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        ApplicationUser? user;
        if ((user = await _userManager.FindByEmailAsync(request.Email)) is null)
            throw new InvalidOperationException("User does not exist with this email");
   
        string token = await _userManager.GeneratePasswordResetTokenAsync(user);
        string resetLink = $"http://localhost:4200/auth/reset-password?email={user.Email}&token={WebUtility.UrlEncode(token)}";

        string html = ForgotPasswordHtml(resetLink, request.Email);

        IConfigurationSection smtpSection = _configuration.GetSection("SMTP");
        string smtpServer = smtpSection.GetSection("Server").Value!;
        int smtpPort = Convert.ToInt32(smtpSection.GetSection("Port").Value!);
        string smtpUser = smtpSection.GetSection("User").Value!;
        string smtpPassword = smtpSection.GetSection("Password").Value!;

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = html,
        };

        MimeMessage emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("DubaWeb", smtpUser));
        emailMessage.To.Add(new MailboxAddress("", request.Email));
        emailMessage.Subject = "Reset Password";

        emailMessage.Body = bodyBuilder.ToMessageBody();

        bool isSuccess = false; 
        using (SmtpClient client = new SmtpClient())
        {
            try
            {
                await client.ConnectAsync(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(smtpUser, smtpPassword);
                await client.SendAsync(emailMessage);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                Console.WriteLine($"Hata: {ex.Message}");
                throw new InvalidProgramException($"Hata: {ex.Message}");
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }
        return isSuccess;

    }

    private string ForgotPasswordHtml(string resetLink, string userEmail)
    {

        string template = "<!DOCTYPE html>" +
            "<html lang=\"en\">" +
            "<head>" +
            "<meta charset=\"UTF-8\">" +
            "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
            "<title>Password Reset</title>" +
            "<style>" +
                    "body { font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; }" +
                    ".container { background-color: white; padding: 20px; border-radius: 8px;" +
                    "box-shadow: 0 4px 8px rgba(0,0,0,0.1); max-width: 600px; margin: 40px auto; text-align: center; }" +
                    ".button { background - color: #4CAF50; border: none; color: white;" +
                    "padding: 15px 32px; text - align: center; text - decoration: none; display: inline - block;" +
                    "font - size: 16px; margin: 20px 2px; margin: 20px 2px; cursor: pointer; border - radius: 4px; }" +
                    "p { font - size: 16px; }" +
                "</style>" +
            "</head>" +
            "<body>" +
            "<div class=\"container\">" +
            "<h1>Hello! Forgot your password?</h1>" +
            $"<p>We received a password reset request for your account: <strong>{{{userEmail}}}</strong >.</p>" +
            "<p> Click the button below to proceed.</p>" +
            $"<a href=\"{resetLink}\" class= \"button\"> Reset Password </a>" +
            " <p> The password reset link is only valid for the next 24 hours.</p>" +
            "</div>" +
            "</body>" +
            "</html>";

        string tmp = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif;'>
                        <h2>Hello! Forgot your password?</h2>
                        <p>We received a password reset request for your account: {userEmail}.</p>
                        <p>Click the button below to proceed.</p>
                        <p>
                            <a href='{resetLink}' style='display:inline-block; padding:10px 20px; font-size:16px; color:#ffffff; background-color:#28a745; text-decoration:none; border-radius:5px;'>Reset Password</a>
                        </p>
                        <p>The password reset link is only valid for the next 24 hours.</p>
                       
                    </body>
                    </html>";
        return tmp;
    }
}
