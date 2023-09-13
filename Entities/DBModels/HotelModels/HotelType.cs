using Entities.EnumData;

namespace Entities.DBModels.HotelModels;

public class HotelType : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(Hotels))]
    public List<Hotel> Hotels { get; set; }
    
    public List<HotelTypeLang> HotelTypeLangs { get; set; }
}

public class HotelTypeLang : AuditLangEntity<HotelType>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}