namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelExtraPriceParameters : RequestParameters
    {
        public int Fk_Hotel { get; set; }

    }
    public class HotelExtraPriceModel : AuditLookUpEntity
    {
        [DisplayName(nameof(Hotel))]
        [ForeignKey(nameof(Hotel))]
        public int Fk_Hotel { get; set; }

        [DisplayName(nameof(Hotel))]
        public HotelModel Hotel { get; set; }

        [DisplayName(nameof(Price))]
        public double Price { get; set; }
    }
}
