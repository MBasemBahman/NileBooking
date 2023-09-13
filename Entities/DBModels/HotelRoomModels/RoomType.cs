namespace Entities.DBModels.HotelRoomModels
{
    public class RoomType : LookUpEntity, IColorEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }

        [DisplayName(nameof(HotelRooms))]
        public List<HotelRoom> HotelRooms { get; set; }

        [DisplayName(nameof(RoomTypeLangs))]
        public List<RoomTypeLang> RoomTypeLangs { get; set; }
    }

    public class RoomTypeLang : AuditLangEntity<RoomType>
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }
    }
}
