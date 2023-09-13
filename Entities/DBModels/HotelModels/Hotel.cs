using Entities.DBModels.LocationModels;
using Entities.EnumData;

namespace Entities.DBModels.HotelModels;

public class Hotel : AuditImageEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public string Name { get; set; }

    [DisplayName(nameof(BookingUrl))]
    public string BookingUrl { get; set; }

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
    public double Rate { get; set; } = 5;

    [DisplayName(nameof(IsActive))]
    public bool IsActive { get; set; }

    [DisplayName(nameof(HotelSelectedFeatures))]
    public List<HotelSelectedFeatures> HotelSelectedFeatures { get; set; }

    [DisplayName(nameof(HotelAttachments))]
    public List<HotelAttachment> HotelAttachments { get; set; }

    public List<HotelLang> HotelLangs { get; set; }
}

public class HotelLang : AuditLangEntity<Hotel>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}