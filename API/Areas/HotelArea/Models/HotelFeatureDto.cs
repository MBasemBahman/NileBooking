using Entities.CoreServicesModels.HotelModels;
using System.ComponentModel;

namespace API.Areas.HotelArea.Models
{
    public class HotelFeatureDto : HotelFeatureModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

        [DisplayName(nameof(HotelFeatureCategory))]
        public new HotelFeatureCategoryDto HotelFeatureCategory { get; set; }
    }
}
