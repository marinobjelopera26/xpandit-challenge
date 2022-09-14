using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace XpandIT.Challenge.DataLayer.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public byte[]? Image { get; set; }

        [MaxLength(150)]
        public string? FirstName { get; set; }

        [MaxLength(150)]
        public string? LastName { get; set; }

        [MaxLength(100)]
        public string? EmailAddress { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }


        public IdentityUser? User { get; set; }
        public ICollection<ContactPhoneNumber>? PhoneNumbers { get; set; }
        public ICollection<ContactGroupContact>? ContactGroups { get; set; }
    }
}
