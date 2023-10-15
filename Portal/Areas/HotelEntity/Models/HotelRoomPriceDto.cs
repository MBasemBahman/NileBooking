using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.HotelRoomModels;

namespace Portal.Areas.HotelEntity.Models
{
    public class HotelRoomPriceDto : HotelRoomPriceModel
    {
        [DisplayName(nameof(FromDate))]
        public new string FromDate => base.FromDate.AddHours(2).ToString(ApiConstants.DateStringFormat);

        [DisplayName(nameof(ToDate))]
        public new string ToDate => base.ToDate.AddHours(2).ToString(ApiConstants.DateStringFormat);
    }
}
