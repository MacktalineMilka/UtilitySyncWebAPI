using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityDataAccess.Repositories;
using UtilityDataAccess.Entity;
using UtilityDataAccess.IRepositories;

namespace UtilityDataAccess.Repositories
{
    public class UserAccountMeterReadingRepository : Repostiory<UserAccountMeterReading>, IUserAccountMeterReadingRepository
    {
        private readonly UtilityDBContext utilityDBContext;
        public UserAccountMeterReadingRepository(UtilityDBContext utilityDBContext) : base(utilityDBContext)
        {
            this.utilityDBContext = utilityDBContext;
        }
    }
}
