using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilityBLL.IServices;
using UtilityDataAccess.Entity;
using UtilityDataAccess.IRepositories;

namespace UtilityBLL.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository userAccountRespository;

        public UserAccountService(IUserAccountRepository userAccountRespository)
        {
            this.userAccountRespository = userAccountRespository;
        }

        public async Task<List<UserAccount>> GetAllUserAccounts()
        {
            var userAccounts = userAccountRespository.GetListAsync().ToList(); 
            return  userAccounts;
        }

        public async Task<UserAccount> GetUserAccountByID(int id)
        {
            return await (Task<UserAccount>)userAccountRespository.GetAsync(id);
        }
    }
}
