using Spectre.Console;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using MailKit.Net.Smtp;
using MimeKit;
using Phonebook.SpyrosZoupas.DAL.Models;
using Phonebook.SpyrosZoupas.DAL.Controllers;

namespace Phonebook.SpyrosZoupas
{
    // we need a service since we are interacting with the BD which shouldn't happen in UI classes
    public class ContactService
    {
        private readonly ContactController _contactController;

        public ContactService(ContactController contactController)
        {
            _contactController = contactController;
        }

        public void InsertContact()
        {
            string name = AnsiConsole.Ask<string>("Contact's name:");
            string email = GetEmailInput("Contact's email");
            string phoneNumber = GetPhoneNumberInput("Contact's phone number");

            _contactController.AddContact(new Contact { Name = name, Email = email, PhoneNumber = phoneNumber });
        }

        private string GetEmailInput(string message)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>($"{message} (please use format email@domain.tld):")
                .Validate((s) =>
                {
                    var emailAddressAttribute = new EmailAddressAttribute();
                    return Regex.IsMatch(s, @"^\w+([-+.']\w+)*@(\[*\w+)([-.]\w+)*\.\w+([-.]\w+\])*$")
                        ? Spectre.Console.ValidationResult.Success()
                        : Spectre.Console.ValidationResult.Error("[red]Invalid email format. Please enter an email in the format of email@domain.tld.[/]");
           
                }));
        }

        private string GetPhoneNumberInput(string message)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>($"{message} (please enter full phone number including country code):")
                .Validate((s) =>
                {
                    var phoneNumberAttribute = new PhoneAttribute();
                    return Regex.Match(s, @"^(\+[0-9]{12})$").Success
                        ? Spectre.Console.ValidationResult.Success()
                        : Spectre.Console.ValidationResult.Error("[red]Invalid phone number format. Example of correct phone number: +441234567899[/]");

                }));
        }

        public void UpdateContact()
        {
            // contact object is being returned from DbContext so from DB so it has accurate ID which is being used to identity
            // which row to update!
            var contact = GetContactOptionInput();

            if (AnsiConsole.Confirm("Update contact name?"))
                contact.Name = AnsiConsole.Ask<string>("Updated name:");

            if (AnsiConsole.Confirm("Update contact email?"))
                contact.Email = GetEmailInput("Updated email");

            if (AnsiConsole.Confirm("Update contact phone number?"))
                contact.PhoneNumber = GetPhoneNumberInput("Updated phone number");

            _contactController.UpdateContact(contact);
        }

        public void DeleteContact() =>
            _contactController.DeleteContact(GetContactOptionInput());

        public List<Contact> GetAllContacts() =>
            _contactController.GetContacts();

        public Contact GetContact() =>
            GetContactOptionInput();

        private Contact GetContactOptionInput()
        {
            var contacts = _contactController.GetContacts();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Contact")
                .AddChoices(contacts.Select(c => c.Name)));

            int id = contacts.First(c => c.Name == option).ContactId;
            return _contactController.GetContactById(id);
        }

        public void SendEmail()
        {
            var contact = GetContactOptionInput();
            MimeMessage mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Spiros Zoupas", "ghideharug@gmail.com"));
            mailMessage.To.Add(new MailboxAddress(contact.Name, contact.Email));

            mailMessage.Subject = "Phonebook application";
            mailMessage.Body = new TextPart("plain")
            {
                Text = @"Hello,

I would like to inform you that your email address and phone number have been saved in my phonebook application.

Regards,
Spiros"
            };

            using var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("ghideharug@gmail.com", "lcdp yvjx pqey cnsu");
            client.Send(mailMessage);
            client.Disconnect(true);
        }
    }
}
