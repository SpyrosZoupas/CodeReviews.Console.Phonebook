using Phonebook.SpyrosZoupas.DAL;
using Spectre.Console;
using System.Net.Http.Headers;

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

        public Contact CreateContactObjectForInsert()
        {
            string name = AnsiConsole.Ask<string>("Contact's name:");
            string email = AnsiConsole.Ask<string>("Contact's email:");
            string phoneNumber = AnsiConsole.Ask<string>("Contact's phone number:");

            return new Contact { Name = name, Email = email, PhoneNumber = phoneNumber };
        }

        public Contact GetContactOptionInput()
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
