using Microsoft.EntityFrameworkCore;
using Phonebook.SpyrosZoupas.DAL.Models;

namespace Phonebook.SpyrosZoupas.DAL.Controllers
{
    public class SkillController
    {
        public void AddSkill(List<ContactSkill> skills)
        {
            using var db = new PhonebookContext();
            db.AddRange(skills);
            db.SaveChanges();
        }

        public void DeleteSkill(Skill Skill)
        {
            using var db = new PhonebookContext();
            db.Remove(Skill);
            db.SaveChanges();
        }
        public void UpdateSkill(Skill Skill)
        {
            using var db = new PhonebookContext();
            db.Update(Skill);
            db.SaveChanges();
        }

        //public Skill GetSkillById(int id)
        //{
        //    using var db = new PhonebookContext();
        //    return db.Categories.SingleOrDefault(c=> c.SkillId == id);
        //}

        //public List<Skill> GetCategories()
        //{
        //    using var db = new PhonebookContext();
        //    return db.Categories
        //        .Include(x => x.Contacts)
        //        .ToList();
        //}
    }
}
