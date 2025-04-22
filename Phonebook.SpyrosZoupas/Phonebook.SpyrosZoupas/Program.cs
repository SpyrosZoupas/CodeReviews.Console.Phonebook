using Phonebook.SpyrosZoupas;
using Phonebook.SpyrosZoupas.DAL.Controllers;
using Phonebook.SpyrosZoupas.Services;

ContactController contactController = new ContactController();
CategoryController categoryController = new CategoryController();
CategoryService categoryService = new CategoryService(categoryController);
ContactService contactService = new ContactService(contactController, categoryService);
UserInterface userInterface = new UserInterface(contactService, categoryService);
userInterface.MainMenu();