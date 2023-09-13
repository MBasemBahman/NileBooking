using Entities.DBModels.BookingModels;
using Entities.DBModels.HotelModels;

namespace Entities.DBModels.HotelRoomModels;

public class HotelRoom : BaseEntity
{
    [DisplayName(nameof(Hotel))]
    [ForeignKey(nameof(Hotel))]
    public int Fk_Hotel { get; set; }

    [DisplayName(nameof(Hotel))]
    public Hotel Hotel { get; set; }

    [DisplayName(nameof(RoomType))]
    [ForeignKey(nameof(RoomType))]
    public int Fk_RoomType { get; set; }

    [DisplayName(nameof(RoomType))]
    public RoomType RoomType { get; set; }

    [DisplayName(nameof(RoomFoodType))]
    [ForeignKey(nameof(RoomFoodType))]
    public int Fk_RoomFoodType { get; set; }

    [DisplayName(nameof(RoomFoodType))]
    public RoomFoodType RoomFoodType { get; set; }

    [DisplayName(nameof(MaxCount))]
    public double MaxCount { get; set; }

    [DisplayName(nameof(HotelRoomPrices))]
    public List<HotelRoomPrice> HotelRoomPrices { get; set; }

    [DisplayName(nameof(BookingRooms))]
    public List<BookingRoom> BookingRooms { get; set; }
}