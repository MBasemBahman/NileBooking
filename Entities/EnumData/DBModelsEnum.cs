namespace Entities.EnumData
{
    public static class DBModelsEnum
    {
        public enum DashboardAccessLevelEnum
        {
            FullAccess = 1,
            DataControl = 2,
            Viewer = 3
        }

        public enum DashboardAdministrationRoleEnum
        {
            Developer = 1,
            Admin = 2,
        }

        public enum DashboardViewEnum
        {
            Home = 1,
            User = 2,
            DashboardAdministrator = 3,
            DashboardAccessLevel = 4,
            DashboardAdministrationRole = 5,
            DashboardView = 6,
            RefreshToken = 7,
            UserDevice = 8,
            Verification = 9,
            AccountState = 10,
            AccountType = 11
        }

        public enum LanguageEnum
        {
            en =1,
        }

        public enum AccountStateEnum
        {
            Active = 1,
            Pending = 2,
            Ban = 3
        }

        public enum AccountTypeEnum
        {
            Client = 1
        }

        public enum RoomTypeEnum
        {
            Single = 1,
            Double = 2,
            Triple = 3
        }

        public enum RoomFoodTypeEnum
        {
            BedAndBreakfast = 1,
            HalfBoard = 2,
            FullBoard = 3,
            AllInclusive = 4,
            RoomOnly = 5,
        }

        public enum HotelTypeEnum
        {
            Hotel = 1,
            Resort = 2,
            Apartment = 3,
            Hostel = 4,
            Villa = 6,
            Motel = 7,
        }

        public enum BookingStateEnum
        {
            Pending = 1,
            Confirmed = 2,
            Cancelled = 3,
            Completed = 4,
            Refunded = 5,
        }
    }
}
