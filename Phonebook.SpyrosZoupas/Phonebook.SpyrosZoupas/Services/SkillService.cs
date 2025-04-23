using Spectre.Console;
using Phonebook.SpyrosZoupas.DAL.Models;
using Phonebook.SpyrosZoupas.DAL.Controllers;
using Phonebook.SpyrosZoupas.Services;

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

        //public void UpdateSkill()
        //{
        //    var category = GetSkillOptionInput();

        //    category.Name = AnsiConsole.Ask<string>("Updated category:");

        //    _categoryController.UpdateSkill(category);
        //}

        //public void DeleteSkill() =>
        //    _categoryController.DeleteSkill(GetSkillOptionInput());

        //public List<Skill> GetAllCategories() =>
        //    _categoryController.GetCategories();

        //public Skill GetSkill() =>
        //    GetSkillOptionInput();

        //public Skill GetSkillOptionInput()
        //{
        //    var categories = _categoryController.GetCategories();
        //    var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
        //        .Title("Choose Skill")
        //        .AddChoices(categories.Select(c => c.Name)));

        //    return categories.First(c => c.Name == option); 
        //}
    }
}
