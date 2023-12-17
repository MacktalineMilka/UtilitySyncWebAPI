using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtilityDataAccess.Entity
{
    [Table("UserAccountsMeterReadings")]
    public class UserAccountMeterReading
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserAccountMeterReadingID { get; set; }

        [ForeignKey("UserAccount")]
        public int AccountID { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
        public int MeterReadValue { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}
