using Phonebook.SpyrosZoupas.DAL;
using Spectre.Console;

namespace Phonebook.SpyrosZoupas
{
    public class UserInput
    {
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
                        ContactController.AddContact();
                        break;
                    case MenuOptions.DeleteContact:
                        ContactController.DeleteContact();
                        break;
                    case MenuOptions.UpdateContact:
                        ContactController.UpdateContact();
                        break;
                    case MenuOptions.ViewContact:
                        ContactController.GetContactById();
                        break;
                    case MenuOptions.ViewAllContacts:
                        ContactController.GetContacts();
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
