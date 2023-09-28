using Entities.CoreServicesModels.AccountModels;
using Entities.EnumData;

namespace Portal.Areas.AccountEntity.Models
{
    public class AccountStateFilter : DtParameters
    {
        public int Id { get; set; }
    }

    public class AccountStateDto : AccountStateModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

    }

    public class AccountStateCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }
        public List<AccountStateLangModel> AccountStateLangs { get; set; }
    }

    public class AccountStateLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
