using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpandIT.Challenge.DataLayer.Entities;

namespace XpandIT.Challenge.DataLayer.Providers
{
    public interface IPhoneNumberRepository
    {
    }

    public class PhoneNumberRepository : RepositoryBase, IPhoneNumberRepository
    {
        public PhoneNumberRepository(XpandITDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
