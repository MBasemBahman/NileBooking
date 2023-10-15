using Entities.CoreServicesModels.HotelRoomModels;
using Entities.CoreServicesModels.LocationModels;

namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelParameters : RequestParameters
    {
        public string TxtSearch { get; set; }
        
        public int Fk_HotelType { get; set; }

        public int Fk_Area { get; set; }

        public int Fk_Country { get; set; }

        public bool? IsActive { get; set; }

        public List<int> Fk_HotelFeatureCategories { get; set; }
        public List<int> Fk_HotelFeatures { get; set; }

        public List<int> Fk_RoomTypes { get; set; }
        public List<int> Fk_RoomFoodTypes { get; set; }

        public bool? IncludeSelectedFeature { get; set; }

        public bool? IncludeRooms { get; set; }

        public bool? IncludeExtraPrices { get; set; }

        public bool? IncludeAttachments { get; set; }

        [DisplayName(nameof(IsRecommended))]
        public bool? IsRecommended { get; set; }

        [DisplayName(nameof(Latitude))]
        public double Latitude { get; set; }

        [DisplayName(nameof(Longitude))]
        public double Longitude { get; set; }

    }
    public class HotelModel : AuditImageEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(Name))]
        public string Name { get; set; }

        [DisplayName(nameof(Price))]
        public double Price { get; set; }

        [DisplayName(nameof(ReviewsCount))]
        public int ReviewsCount { get; set; }
        
        [DisplayName(nameof(Address))]
        public string Address { get; set; }

        [DisplayName(nameof(HotelType))]
        [ForeignKey(nameof(HotelType))]
        public int Fk_HotelType { get; set; }

        [DisplayName(nameof(HotelType))]
        public HotelTypeModel HotelType { get; set; }

        [DisplayName(nameof(Area))]
        [ForeignKey(nameof(Area))]
        public int? Fk_Area { get; set; }

        [DisplayName(nameof(Area))]
        public AreaModel Area { get; set; }

        [DisplayName(nameof(Description))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName(nameof(Rate))]
        public double Rate { get; set; } = 5.0;

        [DisplayName(nameof(IsActive))]
        public bool IsActive { get; set; }

        [DisplayName(nameof(IsRecommended))]
        public bool IsRecommended { get; set; }

        [DisplayName(nameof(Latitude))]
        public double Latitude { get; set; }

        [DisplayName(nameof(Longitude))]
        public double Longitude { get; set; }

        [DisplayName(nameof(Distance))]
        public double Distance { get; set; }

        [DisplayName(nameof(BookingsCount))]
        public int BookingsCount { get; set; }

        [DisplayName(nameof(AttachmentCount))]
        public int AttachmentCount { get; set; }

        [DisplayName(nameof(HotelFeatures))]
        public List<HotelFeatureModel> HotelFeatures { get; set; }


        [DisplayName(nameof(HotelExtras))]
        public List<HotelExtraPriceModel> HotelExtras { get; set; }

        [DisplayName(nameof(HotelRooms))]
        public List<HotelRoomModel> HotelRooms { get; set; }

        [DisplayName(nameof(HotelAttachments))]
        public List<HotelAttachmentModel> HotelAttachments { get; set; }

        [DisplayName("HotelFeatures")]
        public List<HotelSelectedFeaturesWithCategoryModel> HotelSelectedFeatures { get; set; }
    }
}
