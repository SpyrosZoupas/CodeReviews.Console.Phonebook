using Phonebook.SpyrosZoupas.DAL;
using Spectre.Console;

namespace Phonebook.SpyrosZoupas
{
    public class UserInput
    {
        private readonly UserInterface _userInterface;
        private readonly ContactController _contactController;
        private readonly ContactService _contactService;
        public UserInput(UserInterface userInterface, ContactController contactController, ContactService contactService)
        {
            _userInterface = userInterface;
            _contactController = contactController;
            _contactService = contactService;
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
                    MenuOptions.ViewContact,
                    MenuOptions.Quit));

                switch (option)
                {
                    case MenuOptions.AddContact:
                        _contactController.AddContact(_contactService.CreateContactObjectForInsert());
                        break;
                    case MenuOptions.DeleteContact:
                        _contactController.DeleteContact();
                        break;
                    case MenuOptions.UpdateContact:
                        _contactController.UpdateContact();
                        break;
                    case MenuOptions.ViewContact:
                        _userInterface.ShowContact(_contactService.GetContactOptionInput());
                        break;
                    case MenuOptions.ViewAllContacts:
                        _userInterface.ShowContactTable(_contactController.GetContacts());
                        break;
                    case MenuOptions.Quit:
                        Environment.Exit(0);
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
