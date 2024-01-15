using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.AccountModels;

namespace Entities.CoreServicesModels.AccountModels
{
    public class AccountParameters : RequestParameters
    {
        public int Fk_AccountType { get; set; }
        public int Fk_AccountState { get; set; }
        public int Fk_User { get; set; }
        public int ExceptId { get; set; }
        public string UserName { get; set; }
        public bool? HaveBookings { get; set; }
        public DateTime? CreatedAtFrom { get; set; }
        public DateTime? CreatedAtTo { get; set; }
        public string CustomSearch { get; set; }
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

    public class AccountCreateOrEditModel
    {

        [DisplayName(nameof(AccountType))]
        public int Fk_AccountType { get; set; }

        [DisplayName(nameof(AccountState))]
        public int Fk_AccountState { get; set; }
    }
}
