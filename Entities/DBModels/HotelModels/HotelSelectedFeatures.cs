namespace Entities.DBModels.HotelModels;

public class HotelSelectedFeatures : AuditEntity
{
    [DisplayName(nameof(Hotel))]
    [ForeignKey(nameof(Hotel))]
    public int Fk_Hotel { get; set; }

    [DisplayName(nameof(Hotel))]
    public Hotel Hotel { get; set; }

    [DisplayName(nameof(HotelFeature))]
    [ForeignKey(nameof(HotelFeature))]
    public int Fk_HotelFeature { get; set; }

    [DisplayName(nameof(HotelFeature))]
    public HotelFeature HotelFeature { get; set; }
}