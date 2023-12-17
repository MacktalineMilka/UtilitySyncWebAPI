using System.Collections.Generic;
using System.Threading.Tasks;
using UtilityDataAccess.Entity;

namespace UtilityBLL.IServices
{
    public interface IUserAccountService
    {
        Task<List<UserAccount>> GetAllUserAccounts();
        Task<UserAccount> GetUserAccountByID(int id);
    }
}
