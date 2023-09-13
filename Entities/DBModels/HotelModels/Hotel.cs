using Entities.DBModels.BookingModels;
using Entities.DBModels.HotelRoomModels;
using Entities.DBModels.LocationModels;

namespace Entities.DBModels.HotelModels;

public class Hotel : AuditImageEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
    public string Name { get; set; }

    [DisplayName(nameof(LocationUrl))]
    public string LocationUrl { get; set; }

    [DisplayName(nameof(Address))]
    public string Address { get; set; }

    [DisplayName(nameof(HotelType))]
    [ForeignKey(nameof(HotelType))]
    public int Fk_HotelType { get; set; }

    [DisplayName(nameof(HotelType))]
    public HotelType HotelType { get; set; }

    [DisplayName(nameof(Area))]
    [ForeignKey(nameof(Area))]
    public int? Fk_Area { get; set; }

    [DisplayName(nameof(Area))]
    public Area Area { get; set; }

    [DisplayName(nameof(Description))]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    [DisplayName(nameof(Rate))]
    public double Rate { get; set; } = 5.0;

    [DisplayName(nameof(IsActive))]
    public bool IsActive { get; set; }

    [DisplayName(nameof(HotelSelectedFeatures))]
    public List<HotelSelectedFeatures> HotelSelectedFeatures { get; set; }

    [DisplayName(nameof(HotelAttachments))]
    public List<HotelAttachment> HotelAttachments { get; set; }

    [DisplayName(nameof(HotelExtras))]
    public List<HotelExtraPrice> HotelExtras { get; set; }

    [DisplayName(nameof(HotelRooms))]
    public List<HotelRoom> HotelRooms { get; set; }

    [DisplayName(nameof(Bookings))]
    public List<Booking> Bookings { get; set; }

    [DisplayName(nameof(HotelLangs))]
    public List<HotelLang> HotelLangs { get; set; }
}

public class HotelLang : AuditLangEntity<Hotel>
{
    [DisplayName(nameof(Name))]
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}