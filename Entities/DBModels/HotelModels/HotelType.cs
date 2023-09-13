namespace Entities.DBModels.HotelModels;

public class HotelType : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(Hotels))]
    public List<Hotel> Hotels { get; set; }

    [DisplayName(nameof(HotelTypeLangs))]
    public List<HotelTypeLang> HotelTypeLangs { get; set; }
}

public class HotelTypeLang : AuditLangEntity<HotelType>
{
    [DisplayName(nameof(Name))]
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}