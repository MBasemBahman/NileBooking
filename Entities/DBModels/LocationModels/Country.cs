namespace Entities.DBModels.LocationModels;

public class Country : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
    public new string Name { get; set; }

    public List<Area> Areas { get; set; }

    [DisplayName(nameof(CountryLangs))]
    public List<CountryLang> CountryLangs { get; set; }
}

public class CountryLang : AuditLangEntity<Country>
{
    [DisplayName(nameof(Name))]
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}