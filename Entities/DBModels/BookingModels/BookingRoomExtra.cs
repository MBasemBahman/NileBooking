using Entities.DBModels.HotelModels;

namespace Entities.DBModels.BookingModels;

public class BookingRoomExtra : BaseEntity
{
    [DisplayName(nameof(BookingRoom))]
    [ForeignKey(nameof(BookingRoom))]
    public int Fk_BookingRoom { get; set; }

    [DisplayName(nameof(BookingRoom))]
    public BookingRoom BookingRoom { get; set; }

    [DisplayName(nameof(HotelExtra))]
    [ForeignKey(nameof(HotelExtra))]
    public int Fk_HotelExtra { get; set; }

    [DisplayName(nameof(HotelExtra))]
    public HotelExtraPrice HotelExtra { get; set; }

    [DisplayName(nameof(Price))]
    public double Price { get; set; }
}