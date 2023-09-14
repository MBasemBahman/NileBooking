namespace Entities.CoreServicesModels.HotelRoomModels
{
    public class RoomTypeParameters : RequestParameters
    {

    }
    public class RoomTypeModel : LookUpEntity, IColorEntity
    {
        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }
    }
}
