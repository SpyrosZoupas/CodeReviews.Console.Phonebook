using Phonebook.SpyrosZoupas.DAL;
using Spectre.Console;

namespace Phonebook.SpyrosZoupas
{
    public class UserInterface
    {
        public void ShowContact(Contact contact)
        {
            var panel = new Panel($@"Id: {contact.Id}
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
                table.AddRow(contact.Id.ToString(), contact.Name, contact.Email, contact.PhoneNumber);
            }

            AnsiConsole.Write(table);

            Console.WriteLine("Enter any key to go back to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
