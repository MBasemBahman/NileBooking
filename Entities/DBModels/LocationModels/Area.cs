using Entities.EnumData;

namespace Entities.DBModels.LocationModels;

public class Area : AuditLookUpEntity
{
    [DisplayName(nameof(Country))]
    [ForeignKey(nameof(Country))]
    public int Fk_Country { get; set; }

    [DisplayName(nameof(Country))]
    public Country Country { get; set; }

    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    public List<AreaLang> AreaLangs { get; set; }
}

public class AreaLang : AuditLangEntity<Area>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}