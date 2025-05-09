﻿using Spectre.Console;
using Phonebook.SpyrosZoupas.DAL.Models;
using Phonebook.SpyrosZoupas.DAL.Controllers;

namespace Phonebook.SpyrosZoupas
{
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

            category.Name = AnsiConsole.Ask<string>("Updated category:");

            _categoryController.UpdateCategory(category);
        }

        public void DeleteCategory() =>
            _categoryController.DeleteCategory(GetCategoryOptionInput());

        public List<Category> GetAllCategories() =>
            _categoryController.GetCategories();

        public Category GetCategory() =>
            GetCategoryOptionInput();

        public Category GetCategoryOptionInput()
        {
            var categories = _categoryController.GetCategories();
            if (categories.Count == 0) return null;


            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Category")
                .AddChoices(categories.Select(c => c.Name)));

            return categories.First(c => c.Name == option); 
        }
    }
}
