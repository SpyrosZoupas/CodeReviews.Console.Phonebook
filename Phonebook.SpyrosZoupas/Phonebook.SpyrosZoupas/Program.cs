using Phonebook.SpyrosZoupas;
using Phonebook.SpyrosZoupas.DAL.Controllers;
using Phonebook.SpyrosZoupas.Services;
using Phonebook.SpyrosZoupas.Util;

ContactController contactController = new ContactController();
CategoryController categoryController = new CategoryController();
Validation validation = new Validation();
CategoryService categoryService = new CategoryService(categoryController);
ContactService contactService = new ContactService(contactController, categoryService, validation);
UserInterface userInterface = new UserInterface(contactService, categoryService);
userInterface.MainMenu();