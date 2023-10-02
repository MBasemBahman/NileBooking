using Entities.CoreServicesModels.HotelRoomModels;
using Entities.EnumData;

namespace Portal.Areas.HotelRoomEntity.Models
{
    public class RoomFoodTypeFilter : DtParameters
    {

    }
    public class RoomFoodTypeDto : RoomFoodTypeModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }
    }
    public class RoomFoodTypeCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }
        public List<RoomFoodTypeLangModel> RoomFoodTypeLangs { get; set; }
    }

    public class RoomFoodTypeLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
