using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.UserModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using API.Areas.UserArea.Models;

namespace API.Areas.AccountArea.Models
{
    public class AccountDto : AccountModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

        [DisplayName(nameof(User))]
        public new UserDto User { get; set; }

        [DisplayName(nameof(AccountType))]
        public new AccountTypeDto AccountType { get; set; }

        [DisplayName(nameof(AccountState))]
        public new AccountStateDto AccountState { get; set; }
    }

    public class AccountCreateOrEditDto : AccountCreateOrEditModel
    {
        public IFormFile Image { get; set; }
    }
}