using Entities.DBModels.HotelModels;
using Entities.DBModels.RoomModels;
using Entities.EnumData;

namespace Entities.DBModels.BookingModels;

public class BookingRoom : BaseEntity
{
    [DisplayName(nameof(Booking))]
    [ForeignKey(nameof(Booking))]
    public int Fk_Booking { get; set; }

    [DisplayName(nameof(Booking))]
    public Booking Booking { get; set; }
    
    [DisplayName(nameof(HotelRoom))]
    [ForeignKey(nameof(HotelRoom))]
    public int Fk_HotelRoom { get; set; }

    [DisplayName(nameof(HotelRoom))]
    public HotelRoom HotelRoom { get; set; }

    [DisplayName(nameof(AdultCount))]
    public int AdultCount { get; set; }
    
    [DisplayName(nameof(ChildCount))]
    public int ChildCount { get; set; }
    
    [DisplayName(nameof(TotalAdultPrice))]
    public double TotalAdultPrice { get; set; }
    
    [DisplayName(nameof(TotalChildPrice))]
    public double TotalChildPrice { get; set; }
}