using Phonebook.SpyrosZoupas;
using Phonebook.SpyrosZoupas.DAL;

ContactController contactController = new ContactController();
ContactService contactService = new ContactService(contactController);
UserInterface userInterface = new UserInterface();
UserInput userInput = new UserInput(userInterface, contactController, contactService);
userInput.GetUserInput();