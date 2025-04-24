using Spectre.Console;
using Phonebook.SpyrosZoupas.DAL.Models;
using Phonebook.SpyrosZoupas.DAL.Controllers;
using Phonebook.SpyrosZoupas.Services;
using Phonebook.SpyrosZoupas.DAL.Models.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace Phonebook.SpyrosZoupas
{
    // we need a service since we are interacting with the BD which shouldn't happen in UI classes
    public class SkillService
    {
        private readonly SkillController _skillController;
        private readonly ContactService _contactService;

        public SkillService(SkillController skillController, ContactService contactService)
        {
            _skillController = skillController;
            _contactService = contactService;
        }

        public void InsertSkill() =>
            _skillController.AddSkill(GetContactsForSkill());

        private List<ContactSkill> GetContactsForSkill()
        {
            var contacts = new List<ContactSkill>();
            var skill = new Skill();
            skill.Name = AnsiConsole.Ask<string>("Skill name:");

            bool allSkillsListed = false;
            while (!allSkillsListed)
            {
                contacts.Add(
                    new ContactSkill
                    {
                        Skill = skill,
                        ContactId = _contactService.GetContactOptionInput().ContactId,
                    });

                allSkillsListed = !AnsiConsole.Confirm("Would you like to add another contact who has this skill?");
            }

            return contacts;
        }

        public void UpdateSkill()
        {
            var skill = GetSkillOptionInput();

            skill.Name = AnsiConsole.Ask<string>("Updated skill:");

            _skillController.UpdateSkill(skill);
        }

        public void DeleteSkill() =>
            _skillController.DeleteSkill(GetSkillOptionInput());

        public List<Skill> GetAllSkiills() =>
            _skillController.GetSkills();

        public Skill GetSkill() =>
            GetSkillOptionInput();

        public List<ContactForSkillViewDTO> GetContactsForSkill(Skill skill) =>
            skill.ContactSkills
                .Select(x => new ContactForSkillViewDTO
                {
                    Id = x.ContactId,
                    Name = x.Contact.Name,
                    CategoryName = x.Contact.Category.Name
                })
                .ToList();

        public Skill GetSkillOptionInput()
        {   
            var skills = _skillController.GetSkills();
            if (skills.Count == 0) return null;


            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Skill")
                .AddChoices(skills.Select(c => c.Name)));

            return skills.First(c => c.Name == option);
        }
    }
}
