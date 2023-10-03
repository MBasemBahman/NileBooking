namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelFeatureCategoryParameters : RequestParameters
    {
        public bool? IncludeHotelFeatures { get; set; }
    }

    public class HotelFeatureCategoryModel : AuditLookUpEntity
    {
        [DisplayName(nameof(Name))]
        public new string Name { get; set; }

        [DisplayName(nameof(HotelFeatures))]
        public int HotelFeaturesCount { get; set; }

        [DisplayName(nameof(HotelFeaturesPercent))]
        public int HotelFeaturesPercent { get; set; }

        public List<HotelFeatureModel> HotelFeatures { get; set; }
    }

}
