using Microsoft.EntityFrameworkCore;
using XpandIT.Challenge.DataLayer.Entities;

namespace XpandIT.Challenge.DataLayer.Providers
{
    public interface IPhoneNumberTypeRepository
    {
        Task<IEnumerable<CBK_PhoneNumberType>> GetAvailablePhoneNumberTypes();
    }

    public class PhoneNumberTypeRepository : RepositoryBase, IPhoneNumberTypeRepository
    {
        public PhoneNumberTypeRepository(XpandITDbContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<IEnumerable<CBK_PhoneNumberType>> GetAvailablePhoneNumberTypes()
             => await DbContext.PhoneNumberTypes.ToListAsync();
    }
}
