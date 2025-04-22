using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phonebook.SpyrosZoupas.DAL.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [IgnoreForDisplay]
        public int CategoryId { get; set; }

        [IgnoreForDisplay]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
