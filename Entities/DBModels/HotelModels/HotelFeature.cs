namespace Entities.DBModels.HotelModels;

public class HotelFeature : AuditLookUpEntity
{
    [DisplayName(nameof(HotelFeatureCategory))]
    [ForeignKey(nameof(HotelFeatureCategory))]
    public int Fk_HotelFeatureCategory { get; set; }

    [DisplayName(nameof(HotelFeatureCategory))]
    public HotelFeatureCategory HotelFeatureCategory { get; set; }

    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(HotelSelectedFeatures))]
    public List<HotelSelectedFeatures> HotelSelectedFeatures { get; set; }

    [DisplayName(nameof(HotelFeatureLangs))]
    public List<HotelFeatureLang> HotelFeatureLangs { get; set; }
}

public class HotelFeatureLang : AuditLangEntity<HotelFeature>
{
    [DisplayName(nameof(Name))]
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}