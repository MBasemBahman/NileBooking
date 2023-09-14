using Entities.DBModels.AccountModels;
using Entities.DBModels.BookingModels;
using Entities.DBModels.DashboardAdministrationModels;
using Entities.DBModels.HotelModels;
using Entities.DBModels.HotelRoomModels;
using Entities.DBModels.LocationModels;
using Entities.DBModels.SharedModels;
using Entities.DBModels.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ModelBuilderConfig.Configurations.AccountModels;
using ModelBuilderConfig.Configurations.BookingModels;
using ModelBuilderConfig.Configurations.DashboardAdministrationModels;
using ModelBuilderConfig.Configurations.HotelModels;
using ModelBuilderConfig.Configurations.HotelRoomModels;
using ModelBuilderConfig.Configurations.UserModels;

namespace BaseDB
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        #region Account Models
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountState> AccountStates { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        #endregion

        #region DashboardAdministrationModels

        public DbSet<AdministrationRolePremission> AdministrationRolePremissions { get; set; }
        public DbSet<DashboardAccessLevel> DashboardAccessLevels { get; set; }
        public DbSet<DashboardAdministrationRole> DashboardAdministrationRoles { get; set; }
        public DbSet<DashboardAdministrator> DashboardAdministrators { get; set; }
        public DbSet<DashboardView> DashboardViews { get; set; }

        #endregion

        #region Booking Models
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingReview> BookingReviews { get; set; }
        public DbSet<BookingRoom> BookingRooms { get; set; }
        public DbSet<BookingRoomExtra> BookingRoomExtras { get; set; }
        public DbSet<BookingState> BookingStates { get; set; }

        #endregion

        #region Hotel Models
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelAttachment> HotelAttachments { get; set; }
        public DbSet<HotelExtraPrice> HotelExtraPrices { get; set; }
        public DbSet<HotelFeature> HotelFeatures { get; set; }
        public DbSet<HotelFeatureCategory> HotelFeatureCategories { get; set; }
        public DbSet<HotelSelectedFeatures> HotelSelectedFeatures { get; set; }
        public DbSet<HotelType> HotelTypes { get; set; }

        #endregion

        #region Hotel Room Models
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<HotelRoomPrice> HotelRoomPrices { get; set; }
        public DbSet<RoomFoodType> roomFoodTypes { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }

        #endregion

        #region Location Models
        public DbSet<Area> Areas { get; set; }
        public DbSet<Country> Countries { get; set; }

        #endregion

        #region User Models
        public DbSet<Device> Devices { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Verification> Verifications { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes()
               .Where(t => t.ClrType.IsSubclassOf(typeof(BaseEntity))))
            {
                _ = modelBuilder.Entity(
                    entityType.Name,
                    x =>
                    {
                        _ = x.Property("CreatedAt")
                            .HasDefaultValueSql("getutcdate()");
                    });
            }

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes()
               .Where(t => t.ClrType.IsSubclassOf(typeof(AuditEntity))))
            {
                _ = modelBuilder.Entity(
                    entityType.Name,
                    x =>
                    {
                        _ = x.Property("LastModifiedAt")
                            .HasDefaultValueSql("getutcdate()");
                    });
            }

            #region User Models
            _ = modelBuilder.ApplyConfiguration(new UserConfiguration());
            #endregion

            #region DashboardAdministration Models

            _ = modelBuilder.ApplyConfiguration(new DashboardAccessLevelConfiguration());
            _ = modelBuilder.ApplyConfiguration(new DashboardAdministrationRoleConfiguration());
            _ = modelBuilder.ApplyConfiguration(new DashboardAdministrationRoleLangConfiguration());
            _ = modelBuilder.ApplyConfiguration(new AdministrationRolePremissionConfiguration());
            _ = modelBuilder.ApplyConfiguration(new DashboardAdministratorConfiguration());

            #endregion

            #region Account Models

            _ = modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            _ = modelBuilder.ApplyConfiguration(new AccountTypeLangConfiguration());

            _ = modelBuilder.ApplyConfiguration(new AccountStateConfiguration());
            _ = modelBuilder.ApplyConfiguration(new AccountStateLangConfiguration());

            #endregion

            #region Booking Models

            _ = modelBuilder.ApplyConfiguration(new BookingStateConfiguration());
            _ = modelBuilder.ApplyConfiguration(new BookingStateLangConfiguration());

            #endregion


            #region Hotel Models

            _ = modelBuilder.ApplyConfiguration(new HotelTypeConfiguration());
            _ = modelBuilder.ApplyConfiguration(new HotelTypeLangConfiguration());

            #endregion


            #region Hotel Room Models

            _ = modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
            _ = modelBuilder.ApplyConfiguration(new RoomTypeLangConfiguration());

            _ = modelBuilder.ApplyConfiguration(new RoomFoodTypeConfiguration());
            _ = modelBuilder.ApplyConfiguration(new RoomFoodTypeLangConfiguration());

            #endregion

        }
    }
}