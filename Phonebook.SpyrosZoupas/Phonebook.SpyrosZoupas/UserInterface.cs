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
        private readonly SkillService _skillService;

        public UserInterface(ContactService contactService, CategoryService categoryService, SkillService skillService)
        {
            _contactService = contactService;
            _categoryService = categoryService;
            _skillService = skillService;
        }

        public void MainMenu()
        {
            var isAppRunning = true;
            while (isAppRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        MainMenuOptions.ManageContacts,
                        MainMenuOptions.ManageCategories,
                        MainMenuOptions.ManageSkills,
                        MainMenuOptions.Quit));

                switch (option)
                {
                    case MainMenuOptions.ManageContacts:
                        ContactsMenu();
                        break;
                    case MainMenuOptions.ManageCategories:
                        CategoriesMenu();
                        break;
                    case MainMenuOptions.ManageSkills:
                        SkillsMenu();
                        break;
                    case MainMenuOptions.Quit:
                        Console.WriteLine("Bye!");
                        isAppRunning = false;
                        break;
                }
            }
        }

        public void ContactsMenu()
        {
            var isContactMenuRunning = true;
            while (isContactMenuRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                new SelectionPrompt<ContactMenuOptions>()
                .Title("Products Menu")
                .AddChoices(
                    ContactMenuOptions.AddContact,
                    ContactMenuOptions.DeleteContact,
                    ContactMenuOptions.UpdateContact,
                    ContactMenuOptions.ViewAllContacts,
                    ContactMenuOptions.ViewContact,
                    ContactMenuOptions.SendEmail,
                    ContactMenuOptions.GoBack));

                switch (option)
                {
                    case ContactMenuOptions.AddContact:
                        _contactService.InsertContact();
                        break;
                    case ContactMenuOptions.DeleteContact:
                        _contactService.DeleteContact();
                        break;
                    case ContactMenuOptions.UpdateContact:
                        _contactService.UpdateContact();
                        break;
                    case ContactMenuOptions.ViewContact:
                        ShowContact(_contactService.GetContact());
                        break;
                    case ContactMenuOptions.ViewAllContacts:
                        ShowContactTable(_contactService.GetAllContacts());
                        break;
                    case ContactMenuOptions.SendEmail:
                        _contactService.SendEmailToContact();
                        break;
                    case ContactMenuOptions.GoBack:
                        isContactMenuRunning = false;
                        break;
                }
            }
        }

        public void CategoriesMenu()
        {
            var isCategoriesMenuRunning = true;
            while (isCategoriesMenuRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                new SelectionPrompt<CategoryMenuOptions>()
                .Title("Categories Menu")
                .AddChoices(
                    CategoryMenuOptions.AddCategory,
                    CategoryMenuOptions.DeleteCategory,
                    CategoryMenuOptions.UpdateCategory,
                    CategoryMenuOptions.ViewAllCategories,
                    CategoryMenuOptions.ViewCategory,
                    CategoryMenuOptions.GoBack));

                switch (option)
                {
                    case CategoryMenuOptions.AddCategory:
                        _categoryService.InsertCategory();
                        break;
                    case CategoryMenuOptions.DeleteCategory:
                        _categoryService.DeleteCategory();
                        break;
                    case CategoryMenuOptions.UpdateCategory:
                        _categoryService.UpdateCategory();
                        break;
                    case CategoryMenuOptions.ViewCategory:
                        ShowCategory(_categoryService.GetCategory());
                        break;
                    case CategoryMenuOptions.ViewAllCategories:
                        ShowCategoryTable(_categoryService.GetAllCategories());
                        break;
                    case CategoryMenuOptions.GoBack:
                        isCategoriesMenuRunning = false;
                        break;
                }
            }
        }

        public void SkillsMenu()
        {
            var isSkillsMenuRunning = true;
            while (isSkillsMenuRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                new SelectionPrompt<SkillMenuOptions>()
                .Title("Skills Menu")
                .AddChoices(
                    SkillMenuOptions.AddSkill,
                    SkillMenuOptions.DeleteSkill,
                    SkillMenuOptions.UpdateSkill,
                    SkillMenuOptions.ViewAllSkills,
                    SkillMenuOptions.ViewSkill,
                    SkillMenuOptions.GoBack));

                switch (option)
                {
                    case SkillMenuOptions.AddSkill:
                        _skillService.InsertSkill();
                        break;
                    case SkillMenuOptions.DeleteSkill:
                        //_skillService.DeleteSkill();
                        break;
                    case SkillMenuOptions.UpdateSkill:
                        //_skillService.UpdateSkill();
                        break;
                    case SkillMenuOptions.ViewSkill:
                        //_skillService(_categoryService.GetSkill());
                        break;
                    case SkillMenuOptions.ViewAllSkills:
                        //_skillService(_categoryService.GetAllSkills());
                        break;
                    case SkillMenuOptions.GoBack:
                        isSkillsMenuRunning = false;
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
Name: {category.Name}
Number of Contacts under this category: {category.Contacts.Count}");
            panel.Header = new PanelHeader("Category Info");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);

            ShowContactTable(category.Contacts);

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
