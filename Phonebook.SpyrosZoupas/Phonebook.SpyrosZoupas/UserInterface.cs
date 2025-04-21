using Phonebook.SpyrosZoupas.DAL;
using Spectre.Console;

namespace Phonebook.SpyrosZoupas
{
    public class UserInterface
    {
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
