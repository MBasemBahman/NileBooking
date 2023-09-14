using Entities.CoreServicesModels.UserModels;

namespace Entities.CoreServicesModels.DashboardAdministrationModels
{
    public class DashboardAdministratorParameters : RequestParameters
    {
        public int Fk_DashboardAdministrationRole { get; set; }
        public bool GetDevelopers { get; set; } = false;
    }

    public class DashboardAdministratorModel : AuditEntity
    {
        [DisplayName(nameof(User))]
        [ForeignKey(nameof(User))]
        public int Fk_User { get; set; }

        [DisplayName(nameof(User))]
        public UserModel User { get; set; }

        [DisplayName(nameof(JobTitle))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string JobTitle { get; set; }

        [DisplayName(nameof(DashboardAdministrationRole))]
        public int Fk_DashboardAdministrationRole { get; set; }

        [DisplayName(nameof(DashboardAdministrationRole))]
        public DashboardAdministrationRoleModel DashboardAdministrationRole { get; set; }
    }

}
