namespace TenantConfiguration
{
    public class TenantData
    {
        public enum TenantEnvironments
        {
            Development
        }

        public enum TenantApis
        {
            Authentication,
            Account,
            Location,
            Hotel,
            HotelRoom,
            Booking
        }

        public enum TenantViews
        {
            #region Base
            Home,

            // User
            User,
            RefreshToken,
            UserDevice,
            Verification,

            #endregion
        }
    }
}
