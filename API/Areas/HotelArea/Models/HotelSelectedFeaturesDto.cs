using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.SharedModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace API.Areas.HotelArea.Models
{
    public class HotelSelectedFeaturesWithCategoryDto: HotelSelectedFeaturesWithCategoryModel
    {
      
        [DisplayName(nameof(HotelFeatureCategory))]
        public new HotelFeatureCategoryDto HotelFeatureCategory { get; set; }

        [DisplayName(nameof(HotelFeatures))]
        public new List<HotelFeatureDto> HotelFeatures { get; set; }
    }
}
