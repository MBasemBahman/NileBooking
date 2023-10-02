namespace Entities.CoreServicesModels.LocationModels
{
    public class CountryParameters : RequestParameters
    {

    }
    public class CountryModel : AuditLookUpEntity
    {
        [DisplayName(nameof(HotelsCount))]
        public int HotelsCount { get; set; }

        [DisplayName(nameof(AreasCount))]
        public int AreasCount { get; set; }
    }
}
