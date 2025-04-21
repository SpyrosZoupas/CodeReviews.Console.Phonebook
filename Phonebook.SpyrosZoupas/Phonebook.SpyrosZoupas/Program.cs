using Phonebook.SpyrosZoupas;
using Phonebook.SpyrosZoupas.DAL;

ContactController contactController = new ContactController();
UserInterface userInterface = new UserInterface();
ContactService contactService = new ContactService(contactController, userInterface);
UserInput userInput = new UserInput(contactService);
userInput.GetUserInput();