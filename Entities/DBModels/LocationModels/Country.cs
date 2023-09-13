using Entities.EnumData;

namespace Entities.DBModels.LocationModels;

public class Country : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    public List<CountryLang> CountryLangs { get; set; }
}

public class CountryLang : AuditLangEntity<Country>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}