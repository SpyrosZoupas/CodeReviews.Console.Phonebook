using Spectre.Console;

namespace Phonebook.SpyrosZoupas
{
    public class UserInput
    {
        private readonly ContactService _contactService;
        public UserInput(ContactService contactService)
        {
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
                        _contactService.InsertContact();
                        break;
                    case MenuOptions.DeleteContact:
                        _contactService.DeleteContact();
                        break;
                    case MenuOptions.UpdateContact:
                        //_contactController.UpdateContact();
                        break;
                    case MenuOptions.ViewContact:
                        _contactService.GetContact();
                        break;
                    case MenuOptions.ViewAllContacts:
                        _contactService.GetAllContacts();
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
