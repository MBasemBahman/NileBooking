namespace Entities.DBModels.HotelModels;

public class HotelFeatureCategory : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(HotelFeatures))]
    public List<HotelFeature> HotelFeatures { get; set; }

    [DisplayName(nameof(HotelFeatureCategoryLangs))]
    public List<HotelFeatureCategoryLang> HotelFeatureCategoryLangs { get; set; }
}

public class HotelFeatureCategoryLang : AuditLangEntity<HotelFeatureCategory>
{
    [DisplayName(nameof(Name))]
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}