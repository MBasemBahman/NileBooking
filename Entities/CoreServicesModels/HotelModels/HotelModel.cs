using Entities.CoreServicesModels.LocationModels;
using Entities.DBModels.HotelModels;
using Entities.DBModels.LocationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelParameters : RequestParameters
    {
        public int Fk_HotelType { get; set; }

        public int Fk_Area { get; set; }

        public int Fk_Country { get; set; }

        public bool? IsActive { get; set; }

        public bool? IncludeSelectedFeature { get; set; }


    }
    public class HotelModel : AuditImageEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(Name))]
        public string Name { get; set; }

        [DisplayName(nameof(LocationUrl))]
        public string LocationUrl { get; set; }

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

        [DisplayName(nameof(BookingsCount))]
        public int BookingsCount { get; set; }

        [DisplayName("HotelFeatures")]
        public List<HotelSelectedFeaturesWithCategoryModel> HotelSelectedFeatures { get; set; }
    }
}
