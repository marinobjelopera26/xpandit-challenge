using XpandIT.Challenge.DataLayer.Entities;

namespace XpandIT.Challenge.DataLayer.Seeders.Initializers
{
    internal class ContactInitializer : DbInitializerBase<ContactInitializer>
    {
        public override void Execute()
        {
            EnsureDbContextExists();

            if (DbContext!.Contacts?.Any() == true)
                return;

            List<Contact> contacts = new();

            InitializeContactsForUser(
                userId: "a7909d8a-6b8a-4c62-9085-687b71eb6b61",
                ref contacts);

            InitializeContactsForUser(
                userId: "e436d5a1-35ec-4708-9c30-d9032dc54b76",
                ref contacts);

            DbContext.Contacts?.AddRange(contacts);
            DbContext.SaveChanges();
        }

        private void InitializeContactsForUser(string userId, ref List<Contact> contacts)
        {
            for (int i = 0; i < 20; i++)
            {
                var randomGender = Faker!.PickRandom<Bogus.DataSets.Name.Gender>();
                string firstName = Faker.Name.FirstName(randomGender);
                string lastName = Faker.Name.LastName(randomGender);

                Contact contact = new()
                {
                    UserId = userId,
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = Faker.Internet.Email(firstName, lastName)
                };

                contacts.Add(contact);
            }
        }
    }
}
