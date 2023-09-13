namespace Entities.DBModels.HotelRoomModels;

public class HotelRoomPrice : BaseEntity
{
    [DisplayName(nameof(HotelRoom))]
    [ForeignKey(nameof(HotelRoom))]
    public int Fk_HotelRoom { get; set; }

    [DisplayName(nameof(HotelRoom))]
    public HotelRoom HotelRoom { get; set; }

    [DisplayName(nameof(AdultPrice))]
    public double AdultPrice { get; set; }

    [DisplayName(nameof(ChildPrice))]
    public double ChildPrice { get; set; }

    [DisplayName(nameof(FromDate))]
    public DateTime FromDate { get; set; }

    [DisplayName(nameof(ToDate))]
    public DateTime ToDate { get; set; }
}