using API.Areas.HotelRoomArea.Models;
using Entities.CoreServicesModels.BookingModels;
using System.ComponentModel;

namespace API.Areas.BookingArea.Models
{
    public class BookingRoomDto : BookingRoomModel
    {
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(Booking))]
        public new BookingDto Booking { get; set; }

        [DisplayName(nameof(HotelRoom))]
        public new HotelRoomDto HotelRoom { get; set; }
    }

    public class BookingRoomCreateDto
    {
        public int Fk_Booking { get; set; }

        public int Fk_HotelRoom { get; set; }

        [DisplayName(nameof(AdultCount))]
        public int AdultCount { get; set; }

        [DisplayName(nameof(ChildCount))]
        public int ChildCount { get; set; }

        [DisplayName(nameof(TotalAdultPrice))]
        public double TotalAdultPrice { get; set; }

        [DisplayName(nameof(TotalChildPrice))]
        public double TotalChildPrice { get; set; }

        public List<BookingRoomExtraCreateDto> BookingRoomExtras { get; set; }
    }

    public class BookingRoomEditDto
    {


        [DisplayName(nameof(AdultCount))]
        public int AdultCount { get; set; }

        [DisplayName(nameof(ChildCount))]
        public int ChildCount { get; set; }

        [DisplayName(nameof(TotalAdultPrice))]
        public double TotalAdultPrice { get; set; }

        [DisplayName(nameof(TotalChildPrice))]
        public double TotalChildPrice { get; set; }
    }

}
