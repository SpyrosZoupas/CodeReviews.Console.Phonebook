using Microsoft.EntityFrameworkCore;
using Phonebook.SpyrosZoupas.DAL.Models;

namespace Phonebook.SpyrosZoupas.DAL
{
    // ANY changes to the Database Schema require a new migration + update-database command to take effect
    public class ContactContext : DbContext // represents a session with the DB allows you to query the DB
    {
        public DbSet<Contact> Contacts { get; set; } // represents a Contact table. Contact model is a row of Contact table

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer($"Server=(LocalDb)\\TheCSharpAcademy;Database=Phonebook;Trusted_Connection=True;");
    }
}
