using Entities.DBModels.LocationModels;

namespace Entities.CoreServicesModels.LocationModels
{
    public class AreaParameters : RequestParameters
    {
        [DisplayName(nameof(Country))]
        public int Fk_Country { get; set; }
    }
    public class AreaModel : AuditLookUpEntity
    {
        [DisplayName(nameof(Country))]
        [ForeignKey(nameof(Country))]
        public int Fk_Country { get; set; }

        [DisplayName(nameof(Country))]
        public CountryModel Country { get; set; }

        [DisplayName(nameof(HotelsCount))]
        public int HotelsCount { get; set; }
    }
}
