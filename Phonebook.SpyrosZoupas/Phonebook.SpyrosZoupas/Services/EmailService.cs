using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Phonebook.SpyrosZoupas.DAL.Models;
using Spectre.Console;

namespace Phonebook.SpyrosZoupas.Services
{
    public class EmailService
    {
        public bool ConfirmEmail(string email, string name)
        {
            var confirmationEmail = new MimeMessage();

            ConfigurationBuilder configurationBuilder = new();
            IConfiguration configuration = configurationBuilder.AddUserSecrets<EmailService>().Build();

            var smtp_username = configuration.GetSection("Email")["smtp_username"];
            var smtp_password = configuration.GetSection("Email")["smtp_password"];

            confirmationEmail.From.Add(new MailboxAddress("Spyros Zoupas", "ghideharug@gmail.com"));
            confirmationEmail.To.Add(new MailboxAddress(name, email));
            confirmationEmail.Subject = "Phonebook application";
            confirmationEmail.Body = new TextPart("plain")
            {
                Text = @"Hello,

I would like to inform you that your email address and phone number have been saved in my phonebook application.

Regards,
Spiros"
            };

            AnsiConsole.MarkupLine($"[bold fuchsia]Sending confirmation Email to: {email}[/]");

            using SmtpClient smtp = new();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate(smtp_username, smtp_password);
            try
            {
                smtp.Send(confirmationEmail);
            }
            catch (SmtpCommandException e)
            {
                return false;
            }
            smtp.Disconnect(true);

            return true;
        }

        public void SendEmail(Contact contact)
        {
            var email = new MimeMessage();

            ConfigurationBuilder configurationBuilder = new();
            IConfiguration configuration = configurationBuilder.AddUserSecrets<EmailService>().Build();

            var smtp_username = configuration.GetSection("Email")["smtp_username"];
            var smtp_password = configuration.GetSection("Email")["smtp_password"];

            email.From.Add(new MailboxAddress("Spyros Zoupas", "ghideharug@gmail.com"));
            email.To.Add(new MailboxAddress(contact.Name, contact.Email));
            email.Subject = AnsiConsole.Ask<string>("Please write the subject name:");
            email.Body = new TextPart("plain")
            {
                Text = AnsiConsole.Ask<string>("Please write the email:")
            };

            AnsiConsole.MarkupLine($"[bold fuchsia]Sending Email to: {contact.Name} at {contact.Email}[/]");

            using SmtpClient smtp = new();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate(smtp_username, smtp_password);
            try
            {
                smtp.Send(email);
            }
            catch (SmtpCommandException e)
            {
                AnsiConsole.MarkupLine($"[bold black on maroon]Sorry, something went wrong. Unable to send email! Please check your email is in a valid format.[/]");
            }
            smtp.Disconnect(true);
        }
    }
}