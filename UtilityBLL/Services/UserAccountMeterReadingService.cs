using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilityBLL.IServices;
using UtilityDataAccess.Entity;
using UtilityDataAccess.IRepositories;


namespace UtilityBLL.Services
{
    public class UserAccountMeterReadingService : IUserAccountMeterReadingService
    {
        private readonly IUserAccountMeterReadingRepository userAccountMeterReadingRepository;

        public UserAccountMeterReadingService(IUserAccountMeterReadingRepository userAccountMeterReadingRepository)
        {
            this.userAccountMeterReadingRepository = userAccountMeterReadingRepository;
        } 

        public async Task<List<UserAccountMeterReading>> GetAllUserAccountMeterReadings()
        {
            return  userAccountMeterReadingRepository.GetListAsync().ToList();
        }

        public async Task<UserAccountMeterReading> GetUserAccountMeterReadingsByUserAccountID(int userAccountId)
        {
            var userAccountMeterReadings = await GetAllUserAccountMeterReadings();
            return userAccountMeterReadings.Where(c => c.AccountID == userAccountId)?.FirstOrDefault();
        }

        public async Task<UserAccountMeterReading> AddUserAccountMeterReading(UserAccountMeterReading userAccountMeterReading)
        {
            return await userAccountMeterReadingRepository.AddAsync(userAccountMeterReading);
        }

        public async Task<UserAccountMeterReading> UpdateUserAccountMeterReading(UserAccountMeterReading userAccountMeterReading)
        {
            return await userAccountMeterReadingRepository.UpdateAsync(userAccountMeterReading);
        }

        public async Task<UserAccountMeterReading> UserAccountMeterReading(int id)
        {
            return await  userAccountMeterReadingRepository.GetAsync(id);
        }
         
    }
}
