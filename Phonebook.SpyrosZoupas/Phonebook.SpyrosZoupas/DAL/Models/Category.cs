using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Phonebook.SpyrosZoupas.DAL.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [IgnoreForDisplay]
        public List<Contact> Contacts { get; set; }
    }
}
