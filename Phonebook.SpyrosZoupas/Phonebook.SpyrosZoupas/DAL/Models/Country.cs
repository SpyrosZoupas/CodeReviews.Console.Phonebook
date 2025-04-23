namespace Phonebook.SpyrosZoupas.DAL.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public ICollection<CountryContact> CountryContacts { get; set; }
    }
}
