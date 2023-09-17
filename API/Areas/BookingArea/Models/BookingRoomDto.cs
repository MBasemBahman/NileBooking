using Entities.CoreServicesModels.BookingModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using API.Areas.HotelRoomArea.Models;

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
}
