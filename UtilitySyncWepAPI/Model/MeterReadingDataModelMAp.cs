using CsvHelper.Configuration;

namespace UtilitySyncWebAPI.Model
{
    public class MeterReadingDataModelMAp : ClassMap<MeterReadingDataModel>
    {
        public MeterReadingDataModelMAp()
        {
            Map(m => m.AccountId).Name("AccountId");
            Map(m => m.MeterReadingDateTime).Name("MeterReadingDateTime");
            Map(m => m.MeterReadValue).Name("MeterReadValue");
        }
    }
}
