using Entities.CoreServicesModels.HotelRoomModels;

namespace API.Areas.HotelRoomArea.Models
{
    public class RoomTypeDto : RoomTypeModel
    {
        public new string CreatedAt { get; set; }
    }
}
