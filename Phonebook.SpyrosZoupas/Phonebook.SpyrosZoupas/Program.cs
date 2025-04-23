using Phonebook.SpyrosZoupas;
using Phonebook.SpyrosZoupas.DAL;
using Phonebook.SpyrosZoupas.DAL.Controllers;
using Phonebook.SpyrosZoupas.Services;
using Phonebook.SpyrosZoupas.Util;

PhonebookContext context = new PhonebookContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

ContactController contactController = new ContactController();
CategoryController categoryController = new CategoryController();
Validation validation = new Validation();
CategoryService categoryService = new CategoryService(categoryController);
EmailService emailService = new EmailService();
ContactService contactService = new ContactService(contactController, categoryService, emailService, validation);
UserInterface userInterface = new UserInterface(contactService, categoryService);
userInterface.MainMenu();