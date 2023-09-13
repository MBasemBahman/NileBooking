using Entities.DBModels.HotelModels;

namespace Entities.DBModels.LocationModels;

public class Area : AuditLookUpEntity
{
    [DisplayName(nameof(Country))]
    [ForeignKey(nameof(Country))]
    public int Fk_Country { get; set; }

    [DisplayName(nameof(Country))]
    public Country Country { get; set; }

    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(Hotels))]
    public List<Hotel> Hotels { get; set; }

    [DisplayName(nameof(AreaLangs))]
    public List<AreaLang> AreaLangs { get; set; }
}

public class AreaLang : AuditLangEntity<Area>
{
    [DisplayName(nameof(Name))]
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}