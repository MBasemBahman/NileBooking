using Entities.DBModels.AccountModels;
using Entities.DBModels.DashboardAdministrationModels;

namespace Entities.DBModels.UserModels
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User : AuditEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(FirstName))]
        public string FirstName { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(LastName))]
        public string LastName { get; set; }

        [DisplayName(nameof(FullName))]
        public string FullName => $"{FirstName} {LastName}";

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(UserName))]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [PasswordPropertyText]
        [DisplayName(nameof(Password))]
        public string Password { get; set; }

        [DisplayName(nameof(FacebookToken))]
        public string FacebookToken { get; set; }

        [DisplayName(nameof(GoogleToken))]
        public string GoogleToken { get; set; }

        [DisplayName(nameof(TwitterToken))]
        public string TwitterToken { get; set; }

        [DisplayName(nameof(AppleToken))]
        public string AppleToken { get; set; }

        [DisplayName(nameof(LinkedInToken))]
        public string LinkedInToken { get; set; }

        [DisplayName(nameof(InstagramToken))]
        public string InstagramToken { get; set; }

        [DisplayName(nameof(OtherToken))]
        public string OtherToken { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName(nameof(EmailAddress))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string EmailAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [DisplayName(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }

        [DisplayName(nameof(Culture))]
        public string Culture { get; set; }

        [DisplayName(nameof(IsExternalLogin))]
        [DefaultValue(false)]
        public bool IsExternalLogin { get; set; }

        [DisplayName(nameof(DashboardAdministrator))]
        public DashboardAdministrator DashboardAdministrator { get; set; }


        [DisplayName(nameof(Account))]
        public Account Account { get; set; }

        [DisplayName(nameof(RefreshTokens))]
        public List<RefreshToken> RefreshTokens { get; set; }

        [DisplayName(nameof(Verifications))]
        public List<Verification> Verifications { get; set; }

        [DisplayName(nameof(Devices))]
        public IList<Device> Devices { get; set; }
    }
}
