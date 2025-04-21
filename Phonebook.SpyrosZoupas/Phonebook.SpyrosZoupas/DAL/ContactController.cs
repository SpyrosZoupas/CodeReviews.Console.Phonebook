using Spectre.Console;

namespace Phonebook.SpyrosZoupas.DAL
{
    public class ContactController
    {
        public void AddContact(Contact contact)
        {
            using var db = new ContactContext();
            db.Add(contact);
            db.SaveChanges();
        }

        public void DeleteContact(Contact contact)
        {
            using var db = new ContactContext();
            db.Remove(contact);
            db.SaveChanges();
        }
        public void UpdateContact(Contact contact)
        {
            using var db = new ContactContext();
            db.Update(contact);
            db.SaveChanges();
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
    }
}
