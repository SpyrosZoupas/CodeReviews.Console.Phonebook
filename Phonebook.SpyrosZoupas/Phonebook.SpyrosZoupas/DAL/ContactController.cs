using Spectre.Console;

namespace Phonebook.SpyrosZoupas.DAL
{
    public class ContactController
    {
        public static void AddContact()
        {
            string name = AnsiConsole.Ask<string>("Contact's name:");
            string email = AnsiConsole.Ask<string>("Contact's email:");
            string phoneNumber = AnsiConsole.Ask<string>("Contact's phone number:");

            using var db = new ContactContext();
            // EF Core sets auto-increment to properties named ID by default
            db.Add(new Contact { Name = name, Email = email, PhoneNumber = phoneNumber });

            db.SaveChanges();
        }

        public static void DeleteContact()
        {
            throw new NotImplementedException();
        }

        public static void GetContactById()
        {
            throw new NotImplementedException();
        }

        public static void GetContacts()
        {
            throw new NotImplementedException();
        }

        public static void UpdateContact()
        {
            throw new NotImplementedException();
        }
    }
}
