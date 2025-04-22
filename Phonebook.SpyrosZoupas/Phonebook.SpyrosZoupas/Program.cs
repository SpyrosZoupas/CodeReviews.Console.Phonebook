using Phonebook.SpyrosZoupas;
using Phonebook.SpyrosZoupas.DAL.Controllers;
using Phonebook.SpyrosZoupas.Services;

ContactController contactController = new ContactController();
CategoryController categoryController = new CategoryController();
ContactService contactService = new ContactService(contactController);
CategoryService categoryService = new CategoryService(categoryController);
UserInterface userInterface = new UserInterface(contactService, categoryService);
userInterface.MainMenu();