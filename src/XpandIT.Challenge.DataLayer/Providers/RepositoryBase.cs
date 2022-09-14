namespace XpandIT.Challenge.DataLayer.Providers
{
    public abstract class RepositoryBase
    {
        protected readonly XpandITDbContext DbContext;

        public RepositoryBase(XpandITDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
