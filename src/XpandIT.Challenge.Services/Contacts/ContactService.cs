#nullable disable

using Ardalis.GuardClauses;
using XpandIT.Challenge.DataLayer.Providers;
using XpandIT.Challenge.Model.Contacts;

namespace XpandIT.Challenge.Services.Contacts
{
    public interface IContactService
    {
        Task<Contact?> GetContactByIdAsync(string userId, int contactId);
        IEnumerable<Contact> GetUserContactsPaginated(string userId, int currentPage = 1, int pageSize = 10);
        int GetUserContactTotalCount(string userId);

        Task SaveContactAsync(Contact contact);
    }

    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(
            IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IEnumerable<Contact> GetUserContactsPaginated(string userId, int currentPage = 1, int pageSize = 10)
        {
            _ = Guard.Against.NullOrEmpty(userId, nameof(userId));

            return _contactRepository.GetCurrentUserContactsPaginated(userId, currentPage, pageSize)
                        .Select(x =>
                            new Contact(
                                x.Id,
                                x.Image,
                                x.FirstName,
                                x.LastName,
                                x.EmailAddress,
                                x.Address));
        }

        public int GetUserContactTotalCount(string userId)
        {
            _ = Guard.Against.NullOrEmpty(userId, nameof(userId));

            return _contactRepository.GetUserContactTotalCount(userId);
        }

        public async Task<Contact> GetContactByIdAsync(string userId, int contactId)
        {
            _ = Guard.Against.NullOrEmpty(userId, nameof(userId));
            _ = Guard.Against.NegativeOrZero(contactId, nameof(contactId));

            DataLayer.Entities.Contact dbContact = 
                await _contactRepository.GetContactByIdAsync(userId, contactId);

            if (dbContact is null)
                return null;

            Contact contact = new(
                dbContact.Id,
                dbContact.Image,
                dbContact.FirstName,
                dbContact.LastName,
                dbContact.EmailAddress,
                dbContact.Address);

            return contact;
        }

        public async Task SaveContactAsync(Contact contact)
        {
            _ = Guard.Against.Null(contact, nameof(contact));

            await _contactRepository.SaveContactAsync(contact);
        }
    }
}
