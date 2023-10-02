using Entities.CoreServicesModels.BookingModels;
using Entities.EnumData;

namespace Portal.Areas.BookingEntity.Models
{
    public class BookingStateFilter : DtParameters
    {

    }
    public class BookingStateDto : BookingStateModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }
    }

    public class BookingStateCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }
        public List<BookingStateLangModel> BookingStateLangs { get; set; }
    }

    public class BookingStateLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
