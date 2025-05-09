﻿using Microsoft.EntityFrameworkCore;
using Phonebook.SpyrosZoupas.DAL.Models;

namespace Phonebook.SpyrosZoupas.DAL
{
    public class PhonebookContext : DbContext
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["phonebook"].ConnectionString;

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactSkill>()
                .HasKey(cc => new { cc.ContactId, cc.SkillId });

            modelBuilder.Entity<ContactSkill>()
                .HasOne(cs => cs.Contact)
                .WithMany(c => c.ContactSkills)
                .HasForeignKey(cs => cs.ContactId);

            modelBuilder.Entity<ContactSkill>()
                .HasOne(cs => cs.Skill)
                .WithMany(c => c.ContactSkills)
                .HasForeignKey(cs => cs.SkillId);

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
