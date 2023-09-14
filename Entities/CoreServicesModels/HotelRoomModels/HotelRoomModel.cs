using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;
using Entities.DBModels.HotelRoomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CoreServicesModels.HotelRoomModels
{
    public class HotelRoomParameters : RequestParameters
    {
        public int Fk_Hotel { get; set; }
        public int Fk_RoomType { get; set; }
        public int Fk_RoomFoodType { get; set; }

        public bool IncludeRoomPrices { get; set; } = false;

    }
    public class HotelRoomModel : BaseEntity
    {
        [DisplayName(nameof(Hotel))]
        [ForeignKey(nameof(Hotel))]
        public int Fk_Hotel { get; set; }

        [DisplayName(nameof(Hotel))]
        public HotelModel Hotel { get; set; }

        [DisplayName(nameof(RoomType))]
        [ForeignKey(nameof(RoomType))]
        public int Fk_RoomType { get; set; }

        [DisplayName(nameof(RoomType))]
        public RoomTypeModel RoomType { get; set; }

        [DisplayName(nameof(RoomFoodType))]
        [ForeignKey(nameof(RoomFoodType))]
        public int Fk_RoomFoodType { get; set; }

        [DisplayName(nameof(RoomFoodType))]
        public RoomFoodTypeModel RoomFoodType { get; set; }

        [DisplayName(nameof(MaxCount))]
        public double MaxCount { get; set; }

        [DisplayName(nameof(HotelRoomPrices))]
        public List<HotelRoomPriceModel> HotelRoomPrices { get; set; }
    }
}
