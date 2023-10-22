using Entities.CoreServicesModels.HotelModels;
using Entities.CoreServicesModels.HotelRoomModels;
using Entities.EnumData;

namespace Portal.Areas.HotelEntity.Models
{
    public class HotelRoomFilter : DtParameters
    {
        public int Fk_Hotel { get; set; }
    }
    public class HotelRoomDto : HotelRoomModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }


        [DisplayName(nameof(HotelRoomPrices))]
        public new List<HotelRoomPriceDto> HotelRoomPrices { get; set; }
    }

    public class HotelRoomCreateOrEditModel
    {
        [DisplayName(nameof(Fk_Hotel))]
        public int Fk_Hotel { get; set; }

        [DisplayName(nameof(Fk_RoomType))]
        public int Fk_RoomType { get; set; }

        [DisplayName(nameof(Fk_RoomFoodType))]
        public int Fk_RoomFoodType { get; set; }

        [DisplayName(nameof(MaxCount))]
        public double MaxCount { get; set; }

        [DisplayName(nameof(HotelRoomPrices))]
        public List<HotelRoomPriceCreateOrEditModel> HotelRoomPrices { get; set; }
    }
}
