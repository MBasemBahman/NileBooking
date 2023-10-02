using GeoCoordinatePortable;

namespace Services
{
    public class GeoCoordinateService
    {
        public static double GetDistance(
            double sLatitude,
            double sLongitude,
            double dLatitude,
            double dLongitude)
        {
            if (sLatitude > 0 &&
                sLongitude > 0 &&
                dLatitude > 0 &&
                dLongitude > 0)
            {
                GeoCoordinate sCoord = new(sLatitude, sLongitude);
                GeoCoordinate eCoord = new(dLatitude, dLongitude);

                return Math.Round(sCoord.GetDistanceTo(eCoord) / 1000, 1);
            }
            return -1;
        }
    }
}
