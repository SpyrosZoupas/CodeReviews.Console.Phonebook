using Phonebook.SpyrosZoupas.DAL.Models;
using Spectre.Console;
using static Phonebook.SpyrosZoupas.Enums;

namespace Phonebook.SpyrosZoupas
{
    public class UserInterface
    {
        private readonly ContactService _contactService;

        public UserInterface(ContactService contactService)
        {
            _contactService = contactService;
        }

        public void MainMenu()
        {
            var isAppRunning = true;
            while (isAppRunning)
            {
                var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(
                    MenuOptions.AddContact,
                    MenuOptions.DeleteContact,
                    MenuOptions.UpdateContact,
                    MenuOptions.ViewAllContacts,
                    MenuOptions.ViewContact,
                    MenuOptions.SendEmail,
                    MenuOptions.Quit));

                switch (option)
                {
                    case MenuOptions.AddContact:
                        _contactService.InsertContact();
                        break;
                    case MenuOptions.DeleteContact:
                        _contactService.DeleteContact();
                        break;
                    case MenuOptions.UpdateContact:
                        _contactService.UpdateContact();
                        break;
                    case MenuOptions.ViewContact:
                        ShowContact(_contactService.GetContact());
                        break;
                    case MenuOptions.ViewAllContacts:
                        ShowContactTable(_contactService.GetAllContacts());
                        break;
                    case MenuOptions.SendEmail:
                        _contactService.SendEmail();
                        break;
                    case MenuOptions.Quit:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void ShowContact(Contact contact)
        {
            var panel = new Panel($@"Id: {contact.ContactId}
Name: {contact.Name}
Email: {contact.Email}
Phone Number: {contact.PhoneNumber}");
            panel.Header = new PanelHeader("Contact Info");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);

            Console.WriteLine("Enter any key to go back to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        public void ShowContactTable(List<Contact> contacts)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Name");
            table.AddColumn("Email");
            table.AddColumn("Phone Number");

            foreach (Contact contact in contacts)
            {
                table.AddRow(contact.ContactId.ToString(), contact.Name, contact.Email, contact.PhoneNumber);
            }

            AnsiConsole.Write(table);

            Console.WriteLine("Enter any key to go back to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
