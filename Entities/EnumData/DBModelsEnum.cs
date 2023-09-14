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
        }

        public enum LanguageEnum
        {
            en,
            ar
        }

        public enum AccountStateEnum
        {
            Active = 1,
            Pending = 2,
        }

        public enum AccountTypeEnum
        {

        }

        public enum RoomTypeEnum
        {

        }

        public enum RoomFoodTypeEnum
        {

        }

        public enum HotelTypeEnum
        {

        }

        public enum BookingStateEnum
        {

        }
    }
}
