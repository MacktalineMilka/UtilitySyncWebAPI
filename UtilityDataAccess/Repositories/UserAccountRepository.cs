using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityDataAccess.Entity;
using UtilityDataAccess.IRepositories;

namespace UtilityDataAccess.Repositories
{
    public class UserAccountRepository : Repostiory<UserAccount>, IUserAccountRepository
    {
        private readonly UtilityDBContext utilityDBContext;
        public UserAccountRepository(UtilityDBContext utilityDBContext) : base(utilityDBContext)
        {
            this.utilityDBContext = utilityDBContext;
        }
    } 
}
