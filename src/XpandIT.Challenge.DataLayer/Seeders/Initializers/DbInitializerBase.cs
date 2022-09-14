using Ardalis.GuardClauses;

namespace XpandIT.Challenge.DataLayer.Seeders.Initializers
{
    internal abstract class DbInitializerBase<TInitializer> : IDbInitializer
    {
        protected Bogus.Faker? Faker { get; private set; }
        protected XpandITDbContext? DbContext { get; private set; }

        public IDbInitializer Init(XpandITDbContext dbContext)
        {
            _ = Guard.Against.Null(dbContext, nameof(dbContext));

            DbContext = dbContext;

            Faker ??= new(locale: "en");

            return this;
        }

        public abstract void Execute();

        protected void EnsureDbContextExists()
        {
            string initializerName = typeof(TInitializer).Name;

            _ = Guard.Against.Null(
                    input: DbContext,
                    message: $"Unable to execute the DB initializer '{initializerName}' without a DB context instance.");
        }
    }
}
