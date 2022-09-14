#nullable disable

using System.ComponentModel.DataAnnotations;

namespace XpandIT.Challenge.Models
{
    public class AddContactVm
    {
        [Display(Name = "Contact image")]
        public IFormFile Image { get; set; }

        [Required, MaxLength(150)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required, MaxLength(150)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
