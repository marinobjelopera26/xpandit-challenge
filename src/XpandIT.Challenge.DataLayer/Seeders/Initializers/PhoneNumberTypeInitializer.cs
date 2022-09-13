using Ardalis.GuardClauses;
using XpandIT.Challenge.DataLayer.Entities;

namespace XpandIT.Challenge.DataLayer.Seeders.Initializers
{
    internal class PhoneNumberTypeInitializer : DbInitializerBase<PhoneNumberTypeInitializer>
    {
        public override void Execute()
        {
            EnsureDbContextExists();

            if (DbContext!.PhoneNumberTypes?.Any() == true)
                return;

            List<CBK_PhoneNumberType> phoneNumberTypes = new()
            {
                new CBK_PhoneNumberType
                {
                    Name = "Mobile",
                    Description = "Private mobile phone number"
                },
                new CBK_PhoneNumberType
                {
                    Name = "Home",
                    Description = "Home telephone phone number"
                },
                new CBK_PhoneNumberType
                {
                    Name = "Work",
                    Description = "Work mobile phone number"
                },
                new CBK_PhoneNumberType
                {
                    Name = "Work fax",
                    Description = "Work fax machine number"
                },
                new CBK_PhoneNumberType
                {
                    Name = "Home fax",
                    Description = "Home fax machine number"
                },
                new CBK_PhoneNumberType
                {
                    Name = "Pager",
                    Description = "Pager number"
                },
            };
            
            DbContext.PhoneNumberTypes?.AddRange(phoneNumberTypes);
            DbContext.SaveChanges();
        }
    }
}
