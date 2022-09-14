#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XpandIT.Challenge.Models;
using XpandIT.Challenge.Services.Contacts;

namespace XpandIT.Challenge.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IContactService _contactService;

        public IndexModel(
            IContactService contactService,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _contactService = contactService;
        }

        public ContactListVm ContactList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public int TotalPages =>
            (int) Math.Ceiling(decimal.Divide(Count, PageSize));

        public async Task<IActionResult> OnGetAsync()
        {
            ContactList = new ContactListVm();

            IdentityUser user = await _userManager.GetUserAsync(User);

            ContactList.Items = _contactService
                .GetUserContactsPaginated(user.Id, CurrentPage, PageSize)
                .Select(x => 
                    new ContactListItem(
                        x.Id ?? throw new InvalidDataException("Contact found with no set unique ID"),
                        x.Image,
                        x.FirstName,
                        x.LastName,
                        x.EmailAddress,
                        x.Address));

            Count = _contactService.GetUserContactTotalCount(user.Id);

            if (!string.IsNullOrEmpty(SearchString))
            {
                ContactList.Items = ContactList.Items.Where(x => x.Name.Contains(SearchString));
            }

            return Page();
        }
    }
}
