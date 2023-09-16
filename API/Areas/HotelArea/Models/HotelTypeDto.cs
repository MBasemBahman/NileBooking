using Entities.CoreServicesModels.HotelModels;

namespace API.Areas.HotelArea.Models
{
    public class HotelTypeDto : HotelTypeModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }
    }
}
