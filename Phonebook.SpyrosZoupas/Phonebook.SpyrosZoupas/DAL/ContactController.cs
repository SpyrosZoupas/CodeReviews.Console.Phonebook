using Spectre.Console;

namespace Phonebook.SpyrosZoupas.DAL
{
    public class ContactController
    {
        public void AddContact(Contact contact)
        {
            using var db = new ContactContext();
            // EF Core sets auto-increment to properties named ID by default
            db.Add(contact);

            db.SaveChanges();
        }

        public void DeleteContact()
        {
            using var db = new ContactContext();
            //db.Remove();
        }

        public Contact GetContactById(int id)
        {
            using var db = new ContactContext();
            return db.Contacts.SingleOrDefault(c=> c.Id == id);
        }

        public List<Contact> GetContacts()
        {
            using var db = new ContactContext();
            return db.Contacts.ToList();
        }

        public void UpdateContact()
        {
            throw new NotImplementedException();
        }
    }
}
