namespace Entities.DBModels.AccountModels
{
    public class AccountState : LookUpEntity, IColorEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }

        [DisplayName(nameof(Accounts))]
        public IList<Account> Accounts { get; set; }

        [DisplayName(nameof(AccountStateLangs))]
        public List<AccountStateLang> AccountStateLangs { get; set; }
    }

    public class AccountStateLang : AuditLangEntity<AccountState>
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }
    }
}
