using System.Collections.Generic;
using System.Threading.Tasks;
using UtilityDataAccess.Entity;

namespace UtilityBLL.IServices
{
    public interface IUserAccountMeterReadingService
    {
        Task<List<UserAccountMeterReading>> GetAllUserAccountMeterReadings();
        Task<UserAccountMeterReading> GetUserAccountMeterReadingsByUserAccountID(int userAccountId);
        Task<UserAccountMeterReading> UserAccountMeterReading(int id); 
        Task<UserAccountMeterReading> AddUserAccountMeterReading(UserAccountMeterReading userAccountMeterReading);
        Task<UserAccountMeterReading> UpdateUserAccountMeterReading(UserAccountMeterReading userAccountMeterReading);

    }
}
