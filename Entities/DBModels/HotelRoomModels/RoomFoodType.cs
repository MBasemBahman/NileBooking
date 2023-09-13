namespace Entities.DBModels.HotelRoomModels
{
    public class RoomFoodType : LookUpEntity, IColorEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }

        [DisplayName(nameof(HotelRooms))]
        public List<HotelRoom> HotelRooms { get; set; }

        [DisplayName(nameof(RoomFoodTypeLangs))]
        public List<RoomFoodTypeLang> RoomFoodTypeLangs { get; set; }
    }

    public class RoomFoodTypeLang : AuditLangEntity<RoomFoodType>
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }
    }
}
