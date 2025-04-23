namespace Phonebook.SpyrosZoupas.DAL.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public ICollection<ContactSkill> ContactSkills { get; set; }
    }
}
