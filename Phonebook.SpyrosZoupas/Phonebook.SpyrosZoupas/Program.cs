using Phonebook.SpyrosZoupas;
using Phonebook.SpyrosZoupas.DAL.Controllers;

ContactController contactController = new ContactController();
    ContactService contactService = new ContactService(contactController);
    UserInterface userInterface = new UserInterface(contactService);
    userInterface.MainMenu();