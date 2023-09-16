using API.Areas.HotelArea.Models;
using Entities.CoreServicesModels.HotelRoomModels;
using System.ComponentModel;

namespace API.Areas.HotelRoomArea.Models
{
    public class HotelRoomDto : HotelRoomModel
    {
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(Hotel))]
        public new HotelDto Hotel { get; set; }


        [DisplayName(nameof(RoomType))]
        public new RoomTypeDto RoomType { get; set; }


        [DisplayName(nameof(RoomFoodType))]
        public new RoomFoodTypeDto RoomFoodType { get; set; }

        [DisplayName(nameof(HotelRoomPrices))]
        public new List<HotelRoomPriceDto> HotelRoomPrices { get; set; }
    }
}
