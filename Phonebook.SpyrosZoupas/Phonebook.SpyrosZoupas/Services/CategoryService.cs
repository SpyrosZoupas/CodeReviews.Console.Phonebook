using Spectre.Console;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using MailKit.Net.Smtp;
using MimeKit;
using Phonebook.SpyrosZoupas.DAL.Models;
using Phonebook.SpyrosZoupas.DAL.Controllers;

namespace Phonebook.SpyrosZoupas
{
    // we need a service since we are interacting with the BD which shouldn't happen in UI classes
    public class CategoryService
    {
        private readonly CategoryController _categoryController;

        public CategoryService(CategoryController categoryController)
        {
            _categoryController = categoryController;
        }

        public void InsertCategory() =>
            _categoryController.AddCategory(new Category { Name = AnsiConsole.Ask<string>("Category's name:") });

        public void UpdateCategory()
        {
            var category = GetCategoryOptionInput();

            if (AnsiConsole.Confirm("Update category name?"))
                category.Name = AnsiConsole.Ask<string>("Updated category:");

            _categoryController.UpdateCategory(category);
        }

        public void DeleteCategory() =>
            _categoryController.DeleteCategory(GetCategoryOptionInput());

        public List<Category> GetAllCategories() =>
            _categoryController.GetCategories();

        public Category GetCategory() =>
            GetCategoryOptionInput();

        private Category GetCategoryOptionInput()
        {
            var categories = _categoryController.GetCategories();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Category")
                .AddChoices(categories.Select(c => c.Name)));

            int id = categories.First(c => c.Name == option).CategoryId;
            return _categoryController.GetCategoryById(id);
        }
    }
}
