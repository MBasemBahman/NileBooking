using Entities.CoreServicesModels.UserModels;

namespace Entities.CoreServicesModels.AccountModels
{
    public class AccountParameters : RequestParameters
    {
        public int Fk_AccountType { get; set; }
        public int Fk_AccountState { get; set; }
        public int Fk_User { get; set; }
    }

    public class AccountModel : AuditImageEntity
    {
        [DisplayName(nameof(User))]
        [ForeignKey(nameof(User))]
        public int Fk_User { get; set; }

        [DisplayName(nameof(User))]
        public UserModel User { get; set; }

        [DisplayName(nameof(AccountType))]
        [ForeignKey(nameof(AccountType))]
        public int Fk_AccountType { get; set; }

        [DisplayName(nameof(AccountType))]
        public AccountTypeModel AccountType { get; set; }

        [DisplayName(nameof(AccountState))]
        [ForeignKey(nameof(AccountState))]
        public int Fk_AccountState { get; set; }

        [DisplayName(nameof(AccountState))]
        public AccountStateModel AccountState { get; set; }

        [DisplayName(nameof(BookingsCount))]
        public int BookingsCount { get; set; }
    }

}
