using Entities.EnumData;

namespace Entities.DBModels.RoomModels
{
    public class RoomFoodType : LookUpEntity, IColorEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }

        public List<RoomFoodTypeLang> RoomFoodTypeLangs { get; set; }
    }

    public class RoomFoodTypeLang : AuditLangEntity<RoomFoodType>
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }
    }
}
