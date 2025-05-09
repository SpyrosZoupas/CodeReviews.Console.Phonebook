﻿using Microsoft.EntityFrameworkCore;
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

        public List<Skill> GetSkills()
        {
            using var db = new PhonebookContext();
            return db.Skills
                .Include(s => s.ContactSkills)
                .ThenInclude(cs => cs.Contact)
                .ThenInclude(c => c.Category)
                .ToList();
        }
    }
}
