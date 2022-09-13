using XpandIT.Challenge.DataLayer.Seeders.Initializers;

namespace XpandIT.Challenge.DataLayer.Seeders
{
    internal interface IDbInitializer
    {
        IDbInitializer Init(XpandITDbContext dbContext);
        void Execute();
    }

    public static class DbInitializer
    {
        private static readonly IReadOnlyCollection<(int Order, IDbInitializer Initializer)> Initializers
            = new List<(int Order, IDbInitializer Initializer)>
            {
                (Order: 1, Initializer: new IdentityUserInitializer()),
                (Order: 2, Initializer: new PhoneNumberTypeInitializer()),
                (Order: 3, Initializer: new PhoneNumberInitializer()),
                (Order: 4, Initializer: new ContactInitializer()),
                (Order: 5, Initializer: new ContactPhoneNumberInitializer()),
                (Order: 6, Initializer: new ContactGroupInitializer()),
            };

        public static void Initialize(XpandITDbContext dbContext)
        {
            foreach(var (_, initializer) in Initializers.OrderBy(x => x.Order))
            {
                initializer
                    .Init(dbContext)
                    .Execute();
            }
        }
    }
}
