#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XpandIT.Challenge.Model.Contacts;
using XpandIT.Challenge.Models;
using XpandIT.Challenge.Services.Contacts;
using XpandIT.Challenge.Services.PhoneNumbers;

namespace XpandIT.Challenge.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IContactService _contactService;
        private readonly IPhoneNumberService _phoneNumberService;

        public CreateModel(
            IContactService contactService,
            IPhoneNumberService phoneNumberService,
            UserManager<IdentityUser> userManager)
        {
            _contactService = contactService;
            _phoneNumberService = phoneNumberService;
            _userManager = userManager;
        }

        [BindProperty]
        public AddContactVm Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            IdentityUser user = await _userManager.GetUserAsync(User);

            MemoryStream memoryStream = null;

            if (Input.Image?.Length > 0)
            {
                memoryStream = new MemoryStream();
                await Input.Image.CopyToAsync(memoryStream);
            }

            Contact contact = new(
                id: 0,
                userId: user.Id,
                image: memoryStream?.ToArray(),
                Input.FirstName,
                Input.LastName,
                Input.EmailAddress,
                Input.Address);

            await _contactService.SaveContactAsync(contact);

            return RedirectToPage(pageName: "/Contacts/Index");
        }
    }
}
