using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.BookingModels;
using Entities.DBModels.HotelRoomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CoreServicesModels.BookingModels
{
    public class BookingRoomParameters : RequestParameters
    {
        public int Fk_Booking { get; set; }

        public int Fk_HotelRoom { get; set; }

        public bool IncludeBookingRoomExtra { get; set; } = false;

    }
    public class BookingRoomModel : BaseEntity
    {
        [DisplayName(nameof(Booking))]
        [ForeignKey(nameof(Booking))]
        public int Fk_Booking { get; set; }

        [DisplayName(nameof(Booking))]
        public BookingModel Booking { get; set; }

        [DisplayName(nameof(HotelRoom))]
        [ForeignKey(nameof(HotelRoom))]
        public int Fk_HotelRoom { get; set; }

        [DisplayName(nameof(HotelRoom))]
        public HotelRoomModel HotelRoom { get; set; }

        [DisplayName(nameof(AdultCount))]
        public int AdultCount { get; set; }

        [DisplayName(nameof(ChildCount))]
        public int ChildCount { get; set; }

        [DisplayName(nameof(TotalAdultPrice))]
        public double TotalAdultPrice { get; set; }

        [DisplayName(nameof(TotalChildPrice))]
        public double TotalChildPrice { get; set; }

        [DisplayName(nameof(BookingRoomExtras))]
        public List<BookingRoomExtraModel> BookingRoomExtras { get; set; }

    }
}
