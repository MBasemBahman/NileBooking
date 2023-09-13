using Entities.EnumData;

namespace Entities.DBModels.HotelModels;

public class HotelExtra : AuditLookUpEntity
{
    [DisplayName(nameof(Hotel))]
    [ForeignKey(nameof(Hotel))]
    public int Fk_Hotel { get; set; }

    [DisplayName(nameof(Hotel))]
    public Hotel Hotel { get; set; }

    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(Price))]
    public double Price { get; set; }

    public List<HotelExtraLang> HotelExtraLangs { get; set; }
}

public class HotelExtraLang : AuditLangEntity<HotelExtra>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}