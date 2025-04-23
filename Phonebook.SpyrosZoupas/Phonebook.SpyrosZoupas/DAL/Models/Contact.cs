namespace Phonebook.SpyrosZoupas.DAL.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<CountryContact> CountryContacts { get; set; }
    }
}
