using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.BookingModels;

namespace Entities.CoreServicesModels.BookingModels
{
    public class BookingReviewParameters : RequestParameters
    {
        public int Fk_Booking { get; set; }

        public int Fk_Hotel { get; set; }

        public int Fk_HotelRoom { get; set; }

    }
    public class BookingReviewModel : BaseEntity
    {
        [DisplayName(nameof(Booking))]
        [ForeignKey(nameof(Booking))]
        public int Fk_Booking { get; set; }

        [DisplayName(nameof(Account))]
        public AccountModel Account { get; set; }

        [DisplayName(nameof(Description))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName(nameof(Rate))]
        public double Rate { get; set; } = 5.0;
    }
}
