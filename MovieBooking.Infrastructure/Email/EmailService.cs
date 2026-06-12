using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MovieBooking.Application.Interfaces;

namespace MovieBooking.Infrastructure.Email;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;

    public EmailService(
        IConfiguration configuration)
    {
        _smtpSettings =
            configuration
                .GetSection("SmtpSettings")
                .Get<SmtpSettings>()
            ?? throw new Exception(
                "SMTP settings missing");
    }

    public async Task SendAsync(
        string to,
        string subject,
        string body,
        string? attachmentPath = null)
    {
        var email = new MimeMessage();

        email.From.Add(
            new MailboxAddress(
                _smtpSettings.SenderName,
                _smtpSettings.SenderEmail));

        email.To.Add(
            MailboxAddress.Parse(to));

        email.Subject = subject;

        var builder = new BodyBuilder
        {
            HtmlBody = body
        };

        if (!string.IsNullOrWhiteSpace(
                attachmentPath) &&
            File.Exists(
                attachmentPath))
        {
            builder.Attachments.Add(
                attachmentPath);
        }

        email.Body =
            builder.ToMessageBody();

        using var smtp =
            new SmtpClient();

        await smtp.ConnectAsync(
            _smtpSettings.Host,
            _smtpSettings.Port,
            SecureSocketOptions.StartTls);

        await smtp.AuthenticateAsync(
            _smtpSettings.Username,
            _smtpSettings.Password);

        await smtp.SendAsync(email);

        await smtp.DisconnectAsync(true);
    }
}