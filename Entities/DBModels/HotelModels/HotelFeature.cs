using Entities.EnumData;

namespace Entities.DBModels.HotelModels;

public class HotelFeature : AuditLookUpEntity
{
    [DisplayName(nameof(HotelFeatureCategory))]
    [ForeignKey(nameof(HotelFeatureCategory))]
    public int Fk_HotelFeatureCategory { get; set; }

    [DisplayName(nameof(HotelFeatureCategory))]
    public HotelFeatureCategory HotelFeatureCategory { get; set; }

    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(HotelSelectedFeatures))]
    public List<HotelSelectedFeatures> HotelSelectedFeatures { get; set; }

    public List<HotelFeatureLang> HotelFeatureLangs { get; set; }
}

public class HotelFeatureLang : AuditLangEntity<HotelFeature>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}