using XpandIT.Challenge.DataLayer.Entities;

namespace XpandIT.Challenge.DataLayer.Seeders.Initializers
{
    internal class ContactPhoneNumberInitializer : DbInitializerBase<ContactPhoneNumberInitializer>
    {
        private readonly ISet<int> _usedPhoneNumberIds = new HashSet<int>();

        public override void Execute()
        {
            EnsureDbContextExists();

            if (DbContext!.Contacts?.All(x => x.PhoneNumbers == null) == false)
                return;

            foreach (Contact contact in DbContext!.Contacts!.ToList())
            {
                contact.PhoneNumbers ??= new List<ContactPhoneNumber>();

                int? phoneNumberId = DbContext.PhoneNumbers?.FirstOrDefault(x => !_usedPhoneNumberIds.Contains(x.Id))?.Id;

                if (phoneNumberId.HasValue) {
                    contact.PhoneNumbers.Add(
                        new ContactPhoneNumber()
                        {
                            ContactId = contact.Id,
                            PhoneNumberId = phoneNumberId.Value
                        });

                    _usedPhoneNumberIds.Add(phoneNumberId.Value);
                }
            }

            DbContext.SaveChanges();
        }
    }
}
