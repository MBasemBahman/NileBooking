using Entities.CoreServicesModels.HotelRoomModels;
using System.ComponentModel;

namespace API.Areas.HotelRoomArea.Models
{
    public class HotelRoomPriceDto : HotelRoomPriceModel
    {
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(HotelRoom))]
        public new HotelRoomDto HotelRoom { get; set; }

        [DisplayName(nameof(FromDate))]
        public new string FromDate { get; set; }

        [DisplayName(nameof(ToDate))]
        public new string ToDate { get; set; }
    }
}
