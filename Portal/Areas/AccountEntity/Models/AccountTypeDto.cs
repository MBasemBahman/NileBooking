using Entities.CoreServicesModels.AccountModels;
using Entities.EnumData;

namespace Portal.Areas.AccountEntity.Models
{
    public class AccountTypeFilter : DtParameters
    {
        public int Id { get; set; }
    }

    public class AccountTypeDto : AccountTypeModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

    }

    public class AccountTypeCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }
        public List<AccountTypeLangModel> AccountTypeLangs { get; set; }
    }

    public class AccountTypeLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
