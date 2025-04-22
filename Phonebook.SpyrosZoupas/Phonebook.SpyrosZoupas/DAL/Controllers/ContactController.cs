using Microsoft.EntityFrameworkCore;
using Phonebook.SpyrosZoupas.DAL.Models;

namespace Phonebook.SpyrosZoupas.DAL.Controllers
{
    public class ContactController
    {
        public void AddContact(Contact contact)
        {
            using var db = new PhonebookContext();
            db.Add(contact);
            db.SaveChanges();
        }

        public void DeleteContact(Contact contact)
        {
            using var db = new PhonebookContext();
            db.Remove(contact);
            db.SaveChanges();
        }
        public void UpdateContact(Contact contact)
        {
            using var db = new PhonebookContext();
            db.Update(contact);
            db.SaveChanges();
        }

        public Contact GetContactById(int id)
        {
            using var db = new PhonebookContext();
            return db.Contacts
                .Include(x => x.Category)
                .SingleOrDefault(c=> c.ContactId == id);
        }

        public List<Contact> GetContacts()
        {
            using var db = new PhonebookContext();
            return db.Contacts
                .Include(x => x.Category)
                .ToList();
        }
    }
}
