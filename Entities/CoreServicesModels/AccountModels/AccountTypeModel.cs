namespace Entities.CoreServicesModels.AccountModels
{
    public class AccountTypeParameters : RequestParameters
    {

    }

    public class AccountTypeModel : LookUpEntity, IColorEntity
    {
        [DisplayName(nameof(AccountsCount))]
        public int AccountsCount { get; set; }

        [DisplayName(nameof(AccountsPercent))]
        public int AccountsPercent { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }
    }

}
