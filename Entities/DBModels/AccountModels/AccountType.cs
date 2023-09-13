namespace Entities.DBModels.AccountModels
{
    public class AccountType : LookUpEntity, IColorEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }

        [DisplayName(nameof(Accounts))]
        public IList<Account> Accounts { get; set; }

        [DisplayName(nameof(AccountTypeLangs))]
        public List<AccountTypeLang> AccountTypeLangs { get; set; }
    }

    public class AccountTypeLang : AuditLangEntity<AccountType>
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }
    }
}
