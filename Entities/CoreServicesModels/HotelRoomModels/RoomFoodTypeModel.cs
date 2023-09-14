namespace Entities.CoreServicesModels.HotelRoomModels
{
    public class RoomFoodTypeParameters : RequestParameters
    {

    }

    public class RoomFoodTypeModel : LookUpEntity, IColorEntity
    {
        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }
    }
}
