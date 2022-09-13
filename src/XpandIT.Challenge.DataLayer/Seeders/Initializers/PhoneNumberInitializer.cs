using XpandIT.Challenge.DataLayer.Entities;

namespace XpandIT.Challenge.DataLayer.Seeders.Initializers
{
    internal class PhoneNumberInitializer : DbInitializerBase<PhoneNumberInitializer>
    {
        public override void Execute()
        {
            EnsureDbContextExists();

            if (DbContext!.PhoneNumbers?.Any() == true)
                return;

            List<PhoneNumber> phoneNumbers = new();

            // Generate 80 random phone numbers
            for (int i = 0; i < 80; i++)
            {
                phoneNumbers.Add(
                    new PhoneNumber
                    {
                        Type = Faker!.Random.Number(min: 1, max: 6),
                        Value = Faker.Phone.PhoneNumber()
                    });
            }
            
            DbContext.PhoneNumbers?.AddRange(phoneNumbers);
            DbContext.SaveChanges();
        }
    }
}
