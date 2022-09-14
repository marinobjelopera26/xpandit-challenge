using XpandIT.Challenge.DataLayer.Entities;

namespace XpandIT.Challenge.DataLayer.Seeders.Initializers
{
    internal class ContactGroupInitializer : DbInitializerBase<ContactGroupInitializer>
    {
        public override void Execute()
        {
            EnsureDbContextExists();

            if (DbContext!.ContactGroups?.Any() == true)
                return;

            CreateContactGroupsForUser(userId: "a7909d8a-6b8a-4c62-9085-687b71eb6b61");
            CreateContactGroupsForUser(userId: "e436d5a1-35ec-4708-9c30-d9032dc54b76");
        }

        private void CreateContactGroupsForUser(string userId)
        {
            HashSet<int> usedUserContactIds = new();

            for (int i = 0; i < 3; i++)
            {
                ContactGroup contactGroup = new()
                {
                    UserId = userId,
                    Name = Faker!.Company.CompanyName(formatIndex: 2),
                    Description = Faker!.Lorem.Sentence(wordCount: 10)
                };

                contactGroup.Contacts ??= new List<ContactGroupContact>();

                // add three contacts to a contact group
                for (int j = 0; j < 3; j++)
                {
                    int? groupContactId = DbContext!.Contacts?.FirstOrDefault(x => x.UserId == userId && !usedUserContactIds.Contains(x.Id))?.Id;

                    if (groupContactId.HasValue)
                    {
                        contactGroup.Contacts.Add(
                            new ContactGroupContact
                            {
                                ContactId = groupContactId.Value
                            });

                        usedUserContactIds.Add(groupContactId.Value);
                    }
                }

                DbContext!.ContactGroups?.Add(contactGroup);
            }

            DbContext!.SaveChanges();
        }
    }
}
