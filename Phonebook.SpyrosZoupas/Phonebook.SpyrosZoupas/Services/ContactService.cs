﻿using Spectre.Console;
using Phonebook.SpyrosZoupas.DAL.Models;
using Phonebook.SpyrosZoupas.DAL.Controllers;
using Phonebook.SpyrosZoupas.Util;

namespace Phonebook.SpyrosZoupas.Services
{
    public class ContactService
    {
        private readonly ContactController _contactController;
        private readonly CategoryService _categoryService;
        private readonly EmailService _emailService;
        private readonly SmsService _smsService;
        private readonly Validation _validator;

        public ContactService(ContactController contactController, CategoryService categoryService, EmailService emailService,SmsService smsService, Validation validator)
        {
            _contactController = contactController;
            _categoryService = categoryService;
            _emailService = emailService;
            _smsService = smsService;
            _validator = validator;
        }

        public void InsertContact()
        {
            string name = AnsiConsole.Ask<string>("Contact's name:");
            string email = _validator.GetEmailInput("Contact's email", name);
            string phoneNumber = _validator.GetPhoneNumberInput("Contact's phone number");
            int category = _categoryService.GetCategoryOptionInput().CategoryId;
            Contact contact = new Contact { Name = name, Email = email, PhoneNumber = phoneNumber, CategoryId = category };

            _contactController.AddContact(contact);
        }

        public void UpdateContact()
        {
            var contact = GetContactOptionInput();

            if (AnsiConsole.Confirm("Update contact name?"))
                contact.Name = AnsiConsole.Ask<string>("Updated name:");
            if (AnsiConsole.Confirm("Update contact email?"))
                contact.Email = _validator.GetEmailInput("Updated email", contact.Name);
            if (AnsiConsole.Confirm("Update contact phone number?"))
                contact.PhoneNumber = _validator.GetPhoneNumberInput("Updated phone number");
            if (AnsiConsole.Confirm("Update category?"))
                contact.Category = _categoryService.GetCategoryOptionInput();

            _contactController.UpdateContact(contact);
        }

        public void DeleteContact() =>
            _contactController.DeleteContact(GetContactOptionInput());

        public List<Contact> GetAllContacts() =>
            _contactController.GetContacts();

        public Contact GetContact() =>
            GetContactOptionInput();

        public Contact GetContactOptionInput()
        {
            var contacts = _contactController.GetContacts();
            if (contacts.Count == 0) return null;

            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Contact")
                .AddChoices(contacts.Select(c => c.Name)));

            int id = contacts.First(c => c.Name == option).ContactId;
            return _contactController.GetContactById(id);
        }
    
        public void SendEmailToContact()
        {
            var contact = GetContactOptionInput();
            if (contact != null) _emailService.SendEmail(contact);
        }

        public void SendSmsToContact()
        {
            var contact = GetContactOptionInput();
            if (contact != null) _smsService.SendMessage(contact);
        }
    }
}
