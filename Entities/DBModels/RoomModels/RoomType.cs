using Entities.EnumData;

namespace Entities.DBModels.RoomModels
{
    public class RoomType : LookUpEntity, IColorEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }

        public List<RoomTypeLang> RoomTypeLangs { get; set; }
    }

    public class RoomTypeLang : AuditLangEntity<RoomType>
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }
    }
}
