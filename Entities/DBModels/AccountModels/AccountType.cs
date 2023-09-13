using Entities.EnumData;

namespace Entities.DBModels.AccountModels
{
    public class AccountType : LookUpEntity, IColorEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }

        [DisplayName(nameof(Accounts))]
        public IList<Account> Accounts { get; set; }

        public List<AccountTypeLang> AccountTypeLangs { get; set; }
    }

    public class AccountTypeLang : AuditLangEntity<AccountType>
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }
    }
}
