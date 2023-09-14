namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelTypeParameters : RequestParameters
    {

    }
    public class HotelTypeModel : AuditLookUpEntity
    {
        [DisplayName(nameof(HotelsCount))]
        public int HotelsCount { get; set; }
    }
}
