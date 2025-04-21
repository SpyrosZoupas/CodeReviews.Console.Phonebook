using Phonebook.SpyrosZoupas.DAL;
using Spectre.Console;

namespace Phonebook.SpyrosZoupas
{
    public class UserInput
    {
        private readonly UserInterface _userInterface;
        private readonly ContactController _contactController;
        
        public UserInput(UserInterface userInterface, ContactController contactController)
        {
            _userInterface = userInterface;
            _contactController = contactController;
        }

        public void GetUserInput()
        {
            var isAppRunning = true;
            while (isAppRunning)
            {
                var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(
                    MenuOptions.AddContact,
                    MenuOptions.DeleteContact,
                    MenuOptions.UpdateContact,
                    MenuOptions.ViewAllContacts,
                    MenuOptions.ViewContact));

                switch (option)
                {
                    case MenuOptions.AddContact:
                        _contactController.AddContact();
                        break;
                    case MenuOptions.DeleteContact:
                        _contactController.DeleteContact();
                        break;
                    case MenuOptions.UpdateContact:
                        _contactController.UpdateContact();
                        break;
                    case MenuOptions.ViewContact:
                        _contactController.GetContactById();
                        break;
                    case MenuOptions.ViewAllContacts:
                        _userInterface.ShowContactTable(_contactController.GetContacts());
                        break;
                }
            }
        }
    }

    enum MenuOptions
    {
        AddContact,
        DeleteContact,
        UpdateContact,
        ViewContact,
        ViewAllContacts,
        Quit
    }
}
