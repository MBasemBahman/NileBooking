using Entities.CoreServicesModels.UserModels;

namespace Portal.Areas.UserEntity.Models
{
    public class UserDto : UserModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }
    }

    public class UserCreateOrEditDto
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(FirstName))]
        public string FirstName { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(LastName))]
        public string LastName { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(UserName))]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [PasswordPropertyText]
        [DisplayName(nameof(Password))]
        public string Password { get; set; }

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

    }
}
