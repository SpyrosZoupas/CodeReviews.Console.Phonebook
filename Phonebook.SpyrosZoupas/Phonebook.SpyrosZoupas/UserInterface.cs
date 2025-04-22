using Phonebook.SpyrosZoupas.DAL.Models;
using Phonebook.SpyrosZoupas.Services;
using Spectre.Console;
using static Phonebook.SpyrosZoupas.Enums;

namespace Phonebook.SpyrosZoupas
{
    public class UserInterface
    {
        private readonly ContactService _contactService;
        private readonly CategoryService _categoryService;

        public UserInterface(ContactService contactService, CategoryService categoryService)
        {
            _contactService = contactService;
            _categoryService = categoryService;
        }

        public void MainMenu()
        {
            var isAppRunning = true;
            while (isAppRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(
                    MenuOptions.AddContact,
                    MenuOptions.DeleteContact,
                    MenuOptions.UpdateContact,
                    MenuOptions.ViewAllContacts,
                    MenuOptions.ViewContact,
                    MenuOptions.SendEmail,
                    MenuOptions.AddCategory,
                    MenuOptions.DeleteCategory,
                    MenuOptions.UpdateCategory,
                    MenuOptions.ViewAllCategories,
                    MenuOptions.ViewCategory,
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
                        _contactService.UpdateContact();
                        break;
                    case MenuOptions.ViewContact:
                        ShowContact(_contactService.GetContact());
                        break;
                    case MenuOptions.ViewAllContacts:
                        ShowContactTable(_contactService.GetAllContacts());
                        break;
                    case MenuOptions.SendEmail:
                        _contactService.SendEmailToContact();
                        break;
                    case MenuOptions.AddCategory:
                        _categoryService.InsertCategory();
                        break;
                    case MenuOptions.DeleteCategory:
                        _categoryService.DeleteCategory();
                        break;
                    case MenuOptions.UpdateCategory:
                        _categoryService.UpdateCategory();
                        break;
                    case MenuOptions.ViewCategory:
                        ShowCategory(_categoryService.GetCategory());
                        break;
                    case MenuOptions.ViewAllCategories:
                        ShowCategoryTable(_categoryService.GetAllCategories());
                        break;
                    case MenuOptions.Quit:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void ShowContact(Contact contact)
        {
            var panel = new Panel($@"Id: {contact.ContactId}
Name: {contact.Name}
Email: {contact.Email}
Phone Number: {contact.PhoneNumber}
Category: {contact.Category.Name}");
            panel.Header = new PanelHeader("Contact Info");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);

            Console.WriteLine("Enter any key to go back to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        public void ShowContactTable(List<Contact> contacts)
        {
            if (contacts.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]No data to display.[/]");
                return;
            }

            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Name");
            table.AddColumn("Email");
            table.AddColumn("Phone Number");
            table.AddColumn("Category");

            foreach (Contact contact in contacts)
            {
                table.AddRow(
                    contact.ContactId.ToString(),
                    contact.Name,
                    contact.Email,
                    contact.PhoneNumber,
                    contact.Category.Name);
            }

            AnsiConsole.Write(table);

            Console.WriteLine("Enter any key to go back to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        public void ShowCategory(Category category)
        {
            var panel = new Panel($@"Id: {category.CategoryId}
Name: {category.Name}");
            panel.Header = new PanelHeader("Category Info");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);

            Console.WriteLine("Enter any key to go back to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        public void ShowCategoryTable(List<Category> categories)
        {
            if (categories.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]No data to display.[/]");
                return;
            }

            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Name");

            foreach (Category category in categories)
            {
                table.AddRow(
                    category.CategoryId.ToString(),
                    category.Name);
            }

            AnsiConsole.Write(table);

            Console.WriteLine("Enter any key to go back to Main Menu");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
