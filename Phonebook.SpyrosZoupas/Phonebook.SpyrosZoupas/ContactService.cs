using Phonebook.SpyrosZoupas.DAL;
using Spectre.Console;

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
            string email = AnsiConsole.Ask<string>("Contact's email:");
            string phoneNumber = AnsiConsole.Ask<string>("Contact's phone number:");

            _contactController.AddContact(new Contact { Name = name, Email = email, PhoneNumber = phoneNumber });
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
