using Entities.CoreServicesModels.HotelModels;
using Entities.EnumData;

namespace Portal.Areas.HotelEntity.Models
{
    public class HotelTypeFilter : DtParameters
    {

    }
    public class HotelTypeDto : HotelTypeModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }
    }

    public class HotelTypeCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        public List<HotelTypeLangModel> HotelTypeLangs { get; set; }
    }

    public class HotelTypeLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
