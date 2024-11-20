using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sakanatcom.Models;

namespace Sakanatcom.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public virtual DbSet<MasterCategoryMenu> MasterCategoryMenu { get; set; }
        public virtual DbSet<MasterContactUsInformation> MasterContactUsInformation { get; set; }
        public virtual DbSet<MasterItemMenu> MasterItemMenu { get; set; }
        public virtual DbSet<MasterMenu> MasterMenu { get; set; }
        public virtual DbSet<MasterOffer> MasterOffer { get; set; }
        public virtual DbSet<MasterPartner> MasterPartner { get; set; }
        public virtual DbSet<MasterService> MasterService { get; set; }
        public virtual DbSet<MasterSlider> MasterSlider { get; set; }
        public virtual DbSet<MasterSocialMedia> MasterSocialMedia { get; set; }
        public virtual DbSet<MasterWorkingHour> MasterWorkingHour { get; set; }
        public virtual DbSet<SystemSetting> SystemSetting { get; set; }
        public virtual DbSet<TransactionBookTable> TransactionBookTable { get; set; }
        public virtual DbSet<TransactionContactUs> TransactionContactUs { get; set; }
        public virtual DbSet<TransactionNewsletter> TransactionNewsletter { get; set; }
        public virtual DbSet<MasterAbout> MasterAbout { get; set; }
    }
}
