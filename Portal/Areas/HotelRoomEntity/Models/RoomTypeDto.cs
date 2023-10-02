using Entities.CoreServicesModels.HotelRoomModels;
using Entities.EnumData;

namespace Portal.Areas.HotelRoomEntity.Models
{
    public class RoomTypeFilter : DtParameters
    {

    }
    public class RoomTypeDto : RoomTypeModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }
    }

    public class RoomTypeCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }
        public List<RoomTypeLangModel> RoomTypeLangs { get; set; }
    }

    public class RoomTypeLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
