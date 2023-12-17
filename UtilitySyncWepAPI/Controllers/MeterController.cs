using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilityBLL.IServices;
using UtilityDataAccess.Entity;
using UtilitySyncWebAPI.Helper;
using UtilitySyncWebAPI.Model;

namespace UtilitySyncWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterController : ControllerBase
    { 
        private readonly IUserAccountMeterReadingService userAccountMeterReadingService;
        private readonly IUserAccountService userAccountService;
        public MeterController(IUserAccountMeterReadingService userAccountMeterReadingService,IUserAccountService userAccountService)
        {
            Console.WriteLine("Testing");
            this.userAccountMeterReadingService = userAccountMeterReadingService;
            this.userAccountService = userAccountService;
        }


        [HttpPost("meter-reading-uploads")]
        public async Task<IActionResult> MeterReadingUploads([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded");
            } 

            try
            {
                int numberofSuccessfulReadings = 0, numberofFailedReadings = 0;
                //load the meter reading from csv
                List<MeterReadingDataModel> meterReadingrecords = CSVHandler<MeterReadingDataModel>.ImportDataFromCSV(file);

                //validate each row of meter reading 
                foreach(var meterReadingrecord in meterReadingrecords.GroupBy(c => c.AccountId))
                {

                    string userAccountID = meterReadingrecord.Key;
                    bool priorUpdatedAccount = false;
                    foreach (var record in meterReadingrecord)
                    {
                        if (int.TryParse(userAccountID, out int Id))
                        {

                            UserAccount userAccount = await userAccountService.GetUserAccountByID(Id);

                            //check the accountId is valid and reading value is in NNNNN format
                            if (userAccount != null && (record.MeterReadValue.Length == 5) && int.TryParse(record.MeterReadValue, out int meterValue) && meterValue > 0  && userAccountID == record.AccountId && !priorUpdatedAccount)
                            {
                                UserAccountMeterReading existingUserAccountMeterReading = await userAccountMeterReadingService.GetUserAccountMeterReadingsByUserAccountID(Id);
                                if (existingUserAccountMeterReading == null)
                                {
                                    UserAccountMeterReading meterReading = new UserAccountMeterReading
                                    {
                                        AccountID = Id,
                                        MeterReadingDateTime = Convert.ToDateTime(record.MeterReadingDateTime),
                                        MeterReadValue = meterValue
                                    };

                                    //insert new meterreading record
                                    await userAccountMeterReadingService.AddUserAccountMeterReading(meterReading);

                                }
                                else
                                {
                                    existingUserAccountMeterReading.MeterReadingDateTime = Convert.ToDateTime(record.MeterReadingDateTime);
                                    existingUserAccountMeterReading.MeterReadValue = meterValue;

                                    //update the existing meterreading
                                    await userAccountMeterReadingService.UpdateUserAccountMeterReading(existingUserAccountMeterReading);

                                }
                                numberofSuccessfulReadings++;
                                priorUpdatedAccount = true;

                            }
                            else
                            {
                                numberofFailedReadings++;
                            }
                        }
                        else
                        {
                            numberofFailedReadings++;
                        }
                    }
                    
                }

                var data = new { NumberofSuccessfulReadings = numberofSuccessfulReadings, NumberofFailedReadings = numberofFailedReadings };
                string result = JsonConvert.SerializeObject(data);
                return new ContentResult
                {
                    Content = result,
                    ContentType = "application/json",
                    StatusCode = 200
                }; 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

    }
}
 


