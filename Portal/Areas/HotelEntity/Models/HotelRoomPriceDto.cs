using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.HotelRoomModels;

namespace Portal.Areas.HotelEntity.Models
{
    public class HotelRoomPriceDto : HotelRoomPriceModel
    {
        [DisplayName(nameof(FromDate))]
        public new string FromDate { get; set; }

        [DisplayName(nameof(ToDate))]
        public new string ToDate { get; set; }
    }
}
