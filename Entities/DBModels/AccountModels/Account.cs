using Entities.DBModels.UserModels;

namespace Entities.DBModels.AccountModels;

public class Account : AuditImageEntity
{
    [DisplayName(nameof(FirstName))]
    public string FirstName { get; set; }

    [DisplayName(nameof(LastName))]
    public string LastName { get; set; }

    [DisplayName(nameof(User))]
    [ForeignKey(nameof(User))]
    public int? Fk_User { get; set; }

    [DisplayName(nameof(AccountType))]
    [ForeignKey(nameof(AccountType))]
    public int Fk_AccountType { get; set; }

    [DisplayName(nameof(AccountType))]
    public AccountType AccountType { get; set; }

    [DisplayName(nameof(AccountState))]
    [ForeignKey(nameof(AccountState))]
    public int Fk_AccountState { get; set; }

    [DisplayName(nameof(AccountState))]
    public AccountState AccountState { get; set; }

    [DisplayName(nameof(User))]
    public User User { get; set; }
}