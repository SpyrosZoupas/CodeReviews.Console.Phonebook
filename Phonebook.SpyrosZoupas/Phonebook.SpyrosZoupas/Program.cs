using Phonebook.SpyrosZoupas;
using Phonebook.SpyrosZoupas.DAL;

ContactController contactController = new ContactController();
UserInterface userInterface = new UserInterface();
UserInput userInput = new UserInput(userInterface, contactController);
userInput.GetUserInput();