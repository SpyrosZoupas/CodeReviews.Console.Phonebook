using Microsoft.EntityFrameworkCore;
using Phonebook.SpyrosZoupas.DAL.Models;
using System;

namespace Phonebook.SpyrosZoupas.DAL
{
    // ANY changes to the Database Schema require a new migration + update-database command to take effect
    public class PhonebookContext : DbContext // represents a session with the DB allows you to query the DB
    {
        public DbSet<Contact> Contacts { get; set; } // represents a Contact table. Contact model is a row of Contact table

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer($"Server=(LocalDb)\\TheCSharpAcademy;Database=Phonebook;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryContact>()
                .HasKey(cc => new { cc.CountryId, cc.ContactId });

            modelBuilder.Entity<CountryContact>()
                .HasOne(cc => cc.Contact)
                .WithMany(c => c.CountryContacts)
                .HasForeignKey(cc => cc.ContactId);

            modelBuilder.Entity<CountryContact>()
                .HasOne(cc => cc.Country)
                .WithMany(c => c.CountryContacts)
                .HasForeignKey(cc => cc.CountryId);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Contacts)
                .HasForeignKey(c => c.CategoryId);
                


            modelBuilder.Entity<Category>()
                .HasData(new List<Category>
                {
                    new Category
                    {
                        CategoryId = 1,
                        Name = "Family"
                    },
                    new Category
                    {
                        CategoryId = 2,
                        Name = "Friends"
                    },
                    new Category
                    {
                        CategoryId = 3,
                        Name = "Coworkers"
                    },
                    new Category
                    {
                        CategoryId = 4,
                        Name = "Strangers"
                    }
                });

            modelBuilder.Entity<Contact>()
                .HasData(new List<Contact>
                {
                    new Contact 
                    {
                        ContactId = 1,
                        CategoryId = 1,
                        Name = "Dummy Name 1",
                        PhoneNumber = "+4412345678901",
                        Email = "dummy@email.com"
                    },
                    new Contact 
                    {
                        ContactId = 2,
                        CategoryId = 1,
                        Name = "Dummy Name 2",
                        PhoneNumber = "+4412345678901",
                        Email = "dummy@email.com"
                    },
                    new Contact 
                    {
                        ContactId = 3,
                        CategoryId = 2,
                        Name = "Dummy Name 3",
                        PhoneNumber = "+4412345678901",
                        Email = "dummy@email.com"
                    },
                    new Contact 
                    {
                        ContactId = 4,
                        CategoryId = 3,
                        Name = "Dummy Name 4",
                        PhoneNumber = "+4412345678901",
                        Email= "dummy@email.com"
                    },
                    new Contact 
                    {
                        ContactId = 5,
                        CategoryId = 4,
                        Name = "Dummy Name 5",
                        PhoneNumber = "+4412345678901",
                        Email="dummy@email.com"
                    },
                    new Contact 
                    {
                        ContactId = 6,
                        CategoryId = 1,
                        Name = "Dummy Name 6",
                        PhoneNumber = "+4412345678901",
                        Email="dummy@email.com"
                    }
                });

        }
    }
}
