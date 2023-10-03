using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.AccountModels;
using Portal.Areas.UserEntity.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Areas.AccountEntity.Models
{
    public class AccountIndexViewModel
    {
        public AccountFilter Filter { get; set; }
    }
    public class AccountFilter : DtParameters
    {
        [DisplayName(nameof(AccountType))]
        public int Fk_AccountType { get; set; }

        [DisplayName(nameof(AccountState))]
        public int Fk_AccountState { get; set; }

        [DisplayName(nameof(HaveBookings))]
        public bool? HaveBookings { get; set; }

        [DisplayName(nameof(CreatedAtFrom))]
        public DateTime? CreatedAtFrom { get; set; }

        [DisplayName(nameof(CreatedAtTo))]
        public DateTime? CreatedAtTo { get; set; }
    }
    public class AccountDto : AccountModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }

        [DisplayName(nameof(User))]
        public new UserDto User { get; set; }

        [DisplayName(nameof(AccountType))]
        public new AccountTypeDto AccountType { get; set; }

        [DisplayName(nameof(AccountState))]
        public new AccountStateDto AccountState { get; set; }
    }

    public class AccountCreateOrEditDto
    {
        public AccountCreateOrEditDto()
        {
            User = new UserCreateOrEditDto();
        }

        [DisplayName(nameof(User))]
        public UserCreateOrEditDto User { get; set; }

        [DisplayName(nameof(AccountType))]
        public int Fk_AccountType { get; set; }

        [DisplayName(nameof(AccountState))]
        public int Fk_AccountState { get; set; }

        [DisplayName(nameof(ImageUrl))]
        public string ImageUrl { get; set; }

        [DisplayName(nameof(StorageUrl))]
        public string StorageUrl { get; set; }

    }
}
