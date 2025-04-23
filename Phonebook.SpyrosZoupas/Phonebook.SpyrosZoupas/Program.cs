using Phonebook.SpyrosZoupas;
using Phonebook.SpyrosZoupas.DAL;
using Phonebook.SpyrosZoupas.DAL.Controllers;
using Phonebook.SpyrosZoupas.Services;
using Phonebook.SpyrosZoupas.Util;

PhonebookContext context = new PhonebookContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

Validation validation = new Validation();

ContactController contactController = new ContactController();
CategoryController categoryController = new CategoryController();
SkillController skillController = new SkillController();

CategoryService categoryService = new CategoryService(categoryController);
EmailService emailService = new EmailService();
ContactService contactService = new ContactService(contactController, categoryService, emailService, validation);
SkillService skillService = new SkillService(skillController, contactService);

UserInterface userInterface = new UserInterface(contactService, categoryService, skillService);
userInterface.MainMenu();