using Microsoft.EntityFrameworkCore;
using XpandIT.Challenge.DataLayer.Entities;

namespace XpandIT.Challenge.DataLayer.Providers
{
    public interface IContactRepository
    {
        IQueryable<Contact> GetCurrentUserContactsPaginated(string userId, int currentPage, int pageSize);
        int GetUserContactTotalCount(string userId);
        Task<Contact?> GetContactByIdAsync(string userId, int contactId);
        Task SaveContactAsync(Model.Contacts.Contact contact);
    }

    public class ContactRepository : RepositoryBase, IContactRepository
    {
        public ContactRepository(XpandITDbContext dbContext)
            : base(dbContext) { }

        public IQueryable<Contact> GetCurrentUserContactsPaginated(string userId, int currentPage, int pageSize) =>
            DbContext!.Contacts?
                .Where(x => x.UserId == userId)
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)

            ?? new List<Contact>().AsQueryable();

        public int GetUserContactTotalCount(string userId) =>
            DbContext!.Contacts?.Count(x => x.UserId == userId)
                ?? 0;

        public Task<Contact?> GetContactByIdAsync(string userId, int contactId) =>
            DbContext!.Contacts?
                .Include(contact => contact.PhoneNumbers)
                .ThenInclude(cpn => cpn.PhoneNumber)
                .SingleOrDefaultAsync(x => x.UserId == userId && x.Id == contactId);

        public async Task SaveContactAsync(Model.Contacts.Contact contact)
        {
            Contact dbContact = new()
            {
                UserId = contact.UserId,
                Image = contact.Image,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                EmailAddress = contact.EmailAddress,
                Address = contact.Address
            };

            DbContext.Contacts!.Add(dbContact);

            await DbContext.SaveChangesAsync();
        }
    }
}
