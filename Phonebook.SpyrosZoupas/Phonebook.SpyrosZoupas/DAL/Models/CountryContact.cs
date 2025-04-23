namespace Phonebook.SpyrosZoupas.DAL.Models
{
    public class CountryContact
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
