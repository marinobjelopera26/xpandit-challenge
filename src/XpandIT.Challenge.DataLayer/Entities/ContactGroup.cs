using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace XpandIT.Challenge.DataLayer.Entities
{
    public class ContactGroup
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }


        public IdentityUser? User { get; set; }
        public ICollection<ContactGroupContact>? Contacts { get; set; }
    }
}
