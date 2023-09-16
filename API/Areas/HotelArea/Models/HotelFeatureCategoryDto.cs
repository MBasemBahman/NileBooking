using Entities.CoreServicesModels.HotelModels;

namespace API.Areas.HotelArea.Models
{
    public class HotelFeatureCategoryDto : HotelFeatureCategoryModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

        public new List<HotelFeatureDto> HotelFeatures { get; set; }

    }
}
