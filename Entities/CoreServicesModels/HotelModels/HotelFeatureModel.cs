namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelFeatureParameters : RequestParameters
    {
        public int Fk_HotelFeatureCategory { get; set; }
    }

    public class HotelFeatureModel : AuditImageEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(Name))]
        public new string Name { get; set; }

        [DisplayName(nameof(HotelFeatureCategory))]
        [ForeignKey(nameof(HotelFeatureCategory))]
        public int Fk_HotelFeatureCategory { get; set; }

        [DisplayName(nameof(HotelFeatureCategory))]
        public HotelFeatureCategoryModel HotelFeatureCategory { get; set; }
    }
}
