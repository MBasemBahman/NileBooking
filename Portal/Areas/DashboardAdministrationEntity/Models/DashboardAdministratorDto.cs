using Portal.Areas.UserEntity.Models;
using Entities.CoreServicesModels.UserModels;
using System.ComponentModel;

namespace Portal.Areas.DashboardAdministrationEntity.Models
{
    public class DashboardAdministratorFilter : DtParameters
    {
        public int Id { get; set; }
        public int Fk_DashboardAdministrationRole { get; set; }

    }
    public class DashboardAdministratorDto : DashboardAdministratorModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }

        public new UserDto User { get; set; }

    }

    public class DashboardAdministratorCreateOrEditDto
    {
        public DashboardAdministratorCreateOrEditDto()
        {
            User = new();
        }
        [DisplayName(nameof(JobTitle))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string JobTitle { get; set; }

        [DisplayName(nameof(IsActive))]
        public bool IsActive { get; set; }

        [DisplayName("DashboardAdministrationRole")]
        public int Fk_DashboardAdministrationRole { get; set; }

        public UserCreateOrEditDto User { get; set; }

    }


}
