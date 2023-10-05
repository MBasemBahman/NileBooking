using API.Areas.HotelArea.Models;
using Entities.CoreServicesModels.BookingModels;
using System.ComponentModel;

namespace API.Areas.BookingArea.Models
{
    public class BookingRoomExtraDto : BookingRoomExtraModel
    {
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(BookingRoom))]
        public new BookingRoomDto BookingRoom { get; set; }

        [DisplayName(nameof(HotelExtra))]
        public new HotelExtraPriceDto HotelExtra { get; set; }
    }

    public class BookingRoomExtraCreateDto
    {
        public int Fk_BookingRoom { get; set; }

        public int Fk_HotelExtra { get; set; }

        public double Price { get; set; }
    }
}
