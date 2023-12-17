using Microsoft.EntityFrameworkCore;
using UtilityDataAccess.Entity;

namespace UtilityDataAccess
{
    public class UtilityDBContext : DbContext
    {
        public UtilityDBContext(DbContextOptions<UtilityDBContext> options)
            : base(options)
        {
            
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserAccountMeterReading> UserAccountMeterReadings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
        }

    }
}
