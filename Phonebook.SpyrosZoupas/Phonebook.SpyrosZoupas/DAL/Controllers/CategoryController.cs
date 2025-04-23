using Microsoft.EntityFrameworkCore;
using Phonebook.SpyrosZoupas.DAL.Models;

namespace Phonebook.SpyrosZoupas.DAL.Controllers
{
    public class CategoryController
    {
        public void AddCategory(Category Category)
        {
            using var db = new PhonebookContext();
            db.Add(Category);
            db.SaveChanges();
        }

        public void DeleteCategory(Category Category)
        {
            using var db = new PhonebookContext();
            db.Remove(Category);
            db.SaveChanges();
        }
        public void UpdateCategory(Category Category)
        {
            using var db = new PhonebookContext();
            db.Update(Category);
            db.SaveChanges();
        }

        public Category GetCategoryById(int id)
        {
            using var db = new PhonebookContext();
            return db.Categories.SingleOrDefault(c=> c.CategoryId == id);
        }

        public List<Category> GetCategories()
        {
            using var db = new PhonebookContext();
            return db.Categories
                .Include(x => x.Contacts)
                .ToList();
        }
    }
}
