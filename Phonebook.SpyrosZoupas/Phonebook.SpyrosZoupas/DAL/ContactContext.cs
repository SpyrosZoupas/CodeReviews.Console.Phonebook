using Microsoft.EntityFrameworkCore;

namespace Phonebook.SpyrosZoupas.DAL
{
    public class ContactContext : DbContext // represents a session with the DB allows you to query the DB
    {
        public DbSet<Contact> Contacts { get; set; } // represents a Contact table. Contact model is a row of Contact table

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer($"Data Source=(LocalDb)\\TheCSharpAcademy");
    }
}
