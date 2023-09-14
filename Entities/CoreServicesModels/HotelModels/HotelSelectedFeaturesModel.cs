namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelSelectedFeaturesParameters : RequestParameters
    {
        public int Fk_Hotel { get; set; }
        public int Fk_HotelFeature { get; set; }
    }

    public class HotelSelectedFeaturesModel : BaseEntity
    {
        [DisplayName(nameof(Hotel))]
        [ForeignKey(nameof(Hotel))]
        public int Fk_Hotel { get; set; }

        [DisplayName(nameof(Hotel))]
        public HotelModel Hotel { get; set; }

        [DisplayName(nameof(HotelFeature))]
        [ForeignKey(nameof(HotelFeature))]
        public int Fk_HotelFeature { get; set; }

        [DisplayName(nameof(HotelFeature))]
        public HotelFeatureModel HotelFeature { get; set; }
    }

    public class HotelSelectedFeaturesWithCategoryModel : AuditEntity
    {
        [DisplayName(nameof(HotelFeatureCategory))]
        [ForeignKey(nameof(HotelFeatureCategory))]
        public int Fk_HotelFeatureCategory { get; set; }

        [DisplayName(nameof(HotelFeatureCategory))]
        public HotelFeatureCategoryModel HotelFeatureCategory { get; set; }

        [DisplayName(nameof(HotelFeatures))]
        public List<HotelFeatureModel> HotelFeatures { get; set; }
    }

}
