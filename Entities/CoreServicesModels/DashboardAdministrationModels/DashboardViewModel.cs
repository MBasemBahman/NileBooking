namespace Entities.CoreServicesModels.DashboardAdministrationModels
{
    public class DashboardViewParameters : RequestParameters
    {
        public int Fk_Role { get; set; }
    }

    public class DashboardViewModel : LookUpEntity
    {
        [DisplayName(nameof(ViewPath))]
        public string ViewPath { get; set; }

        [DisplayName(nameof(PremissionsCount))]
        public int PremissionsCount { get; set; }

    }


}
