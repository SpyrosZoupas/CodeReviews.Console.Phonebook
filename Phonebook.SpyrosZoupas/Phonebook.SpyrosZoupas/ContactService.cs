using Phonebook.SpyrosZoupas.DAL;
using Spectre.Console;
using System.ComponentModel.DataAnnotations;

namespace Phonebook.SpyrosZoupas
{
    // we need a service since we are interacting with the BD which shouldn't happen in UI classes
    public class ContactService
    {
        private readonly ContactController _contactController;
        private readonly UserInterface _userInterface;

        public ContactService(ContactController contactController, UserInterface userInterface)
        {
            _contactController = contactController;
            _userInterface = userInterface;
        }

        public void InsertContact()
        {
            string name = AnsiConsole.Ask<string>("Contact's name:");
            string email = GetEmailInput("Contact's email (please use format email@domain):");
            string phoneNumber = GetPhoneNumberInput("Contact's phone number:");

            _contactController.AddContact(new Contact { Name = name, Email = email, PhoneNumber = phoneNumber });
        }

        private string GetEmailInput(string message)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>(message)
                .Validate((s) =>
                {
                    var emailAddressAttribute = new EmailAddressAttribute();
                    return emailAddressAttribute.IsValid(s)
                        ? Spectre.Console.ValidationResult.Success()
                        : Spectre.Console.ValidationResult.Error("[red]Invalid email format. Please enter an email in the format of email@domain[/]");
           
                }));
        }

        private string GetPhoneNumberInput(string message)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>(message)
                .Validate((s) =>
                {
                    var emailAddressAttribute = new EmailAddressAttribute();
                    return emailAddressAttribute.IsValid(s)
                        ? Spectre.Console.ValidationResult.Success()
                        : Spectre.Console.ValidationResult.Error("[red]Invalid email format.[/]");

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
                contact.Email = GetEmailInput("Updated email (please use format name@domain:");

            if (AnsiConsole.Confirm("Update contact phone number?"))
                contact.PhoneNumber = GetPhoneNumberInput("Updated phone number:");

            _contactController.UpdateContact(contact);
        }

        public void DeleteContact() =>
            _contactController.DeleteContact(GetContactOptionInput());

        public void GetAllContacts() =>
            _userInterface.ShowContactTable(_contactController.GetContacts());

        public void GetContact() =>
            _userInterface.ShowContact(GetContactOptionInput());

        private Contact GetContactOptionInput()
        {
            var contacts = _contactController.GetContacts();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Contact")
                .AddChoices(contacts.Select(c => c.Name)));

            int id = contacts.Single(c => c.Name == option).Id;
            return _contactController.GetContactById(id);
        }
    }
}
