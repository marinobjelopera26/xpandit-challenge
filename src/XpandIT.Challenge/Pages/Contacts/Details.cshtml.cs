#nullable disable

using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XpandIT.Challenge.Model.Contacts;
using XpandIT.Challenge.Models;
using XpandIT.Challenge.Services.Contacts;

namespace XpandIT.Challenge.Pages.Contacts
{
    public class DetailsModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IContactService _contactService;

        public DetailsModel(
            UserManager<IdentityUser> userManager, 
            IContactService contactService)
        {
            _userManager = userManager;
            _contactService = contactService;
        }

        public ContactDetailsVm ContactDetails { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            _ = Guard.Against.NegativeOrZero(Id, nameof(Id));

            IdentityUser user = await _userManager.GetUserAsync(User);
            Contact contact = await _contactService.GetContactByIdAsync(user.Id, Id);

            if (contact is null)
                return RedirectToPage("Error");

            ContactDetails = new ContactDetailsVm(
                contact.Id ?? 0,
                contact.Image,
                contact.FirstName,
                contact.LastName,
                contact.EmailAddress,
                contact.Address);

            return Page();
        }
    }
}
