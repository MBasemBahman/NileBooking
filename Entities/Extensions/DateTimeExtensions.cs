namespace Entities.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToShortDateTimeString(this DateTime value)
        {
            return value.ToString("dd/MM/yyyy hh:mm tt");
        }

        public static string ToLongDateString(this DateTime value)
        {
            return value.ToString("dddd, dd MMMM yyyy");
        }

        public static string ToLongDateTimeString(this DateTime value)
        {
            return value.ToString("dddd, dd MMMM yyyy hh:mm tt");
        }

        public static DateTime NextDate(this DateTime value, DayOfWeek current, DayOfWeek desired)
        {
            int offset = (7 - (int)current + (int)desired) % 7;
            return value.AddDays(offset).Date;
        }

        public static DateTime NextDate(this DateTime value, DayOfWeek dayOfWeek)
        {
            int diff = (dayOfWeek - value.DayOfWeek + 7) % 7;
            return value.AddDays(diff).Date;
        }
    }
}
