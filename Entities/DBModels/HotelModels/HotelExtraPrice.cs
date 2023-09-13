using Entities.DBModels.BookingModels;

namespace Entities.DBModels.HotelModels;

public class HotelExtraPrice : AuditLookUpEntity
{
    [DisplayName(nameof(Hotel))]
    [ForeignKey(nameof(Hotel))]
    public int Fk_Hotel { get; set; }

    [DisplayName(nameof(Hotel))]
    public Hotel Hotel { get; set; }

    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(Price))]
    public double Price { get; set; }

    [DisplayName(nameof(BookingRoomExtras))]
    public List<BookingRoomExtra> BookingRoomExtras { get; set; }

    [DisplayName(nameof(HotelExtraPriceLangs))]
    public List<HotelExtraPriceLang> HotelExtraPriceLangs { get; set; }
}

public class HotelExtraPriceLang : AuditLangEntity<HotelExtraPrice>
{
    [DisplayName(nameof(Name))]
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}