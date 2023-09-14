namespace Entities.CoreServicesModels.BookingModels
{
    public class BookingStateParameters : RequestParameters
    {

    }
    public class BookingStateModel : LookUpEntity, IColorEntity
    {
        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }

        [DisplayName(nameof(BookingsCount))]
        public int BookingsCount { get; set; }

    }
}
