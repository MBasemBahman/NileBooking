using Entities.DBModels.DashboardAdministrationModels;
using Entities.EnumData;

namespace Entities.CoreServicesModels.DashboardAdministrationModels
{
    public class DashboardAdministrationRoleRequestParameters : RequestParameters
    {
        public bool GetDeveloperRole { get; set; } = true;
    }
    public class DashboardAdministrationRoleModel : LookUpEntity
    {
        [DisplayName(nameof(PremissionsCount))]
        public int PremissionsCount { get; set; }

        [DisplayName(nameof(AdministratorsCount))]
        public int AdministratorsCount { get; set; }

          }

  

    public class DashboardAdministrationRoleLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }

   public class DashboardAdministrationRoleCreateOrEditModel
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public  string Name { get; set; }

  

        [DisplayName(nameof(DashboardAdministrationRoleLangs))]
        public List<DashboardAdministrationRoleLangModel> DashboardAdministrationRoleLangs { get; set; }

        public List<AdministrationRolePremissionCreateOrEditModel> RolePremissions { get; set; }
    }

    public class AdministrationRolePremissionCreateOrEditModel
    {
        public int Fk_DashboardAccessLevel { get; set; }
        [DisplayName(nameof(DashboardView))]
        public List<int> Fk_DashboardView { get; set; }
    }
}
