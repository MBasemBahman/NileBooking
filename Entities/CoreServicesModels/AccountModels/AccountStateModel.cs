using Entities.EnumData;

namespace Entities.CoreServicesModels.AccountModels
{
    public class AccountStateParameters : RequestParameters
    {

    }

    public class AccountStateModel : LookUpEntity, IColorEntity
    {
        [DisplayName(nameof(AccountsCount))]
        public int AccountsCount { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }
    }

}
