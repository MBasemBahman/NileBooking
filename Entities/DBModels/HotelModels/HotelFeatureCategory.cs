using Entities.EnumData;

namespace Entities.DBModels.HotelModels;

public class HotelFeatureCategory : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(HotelFeatures))]
    public List<HotelFeature> HotelFeatures { get; set; }

    public List<HotelFeatureCategoryLang> HotelFeatureCategoryLangs { get; set; }
}

public class HotelFeatureCategoryLang : AuditLangEntity<HotelFeatureCategory>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}