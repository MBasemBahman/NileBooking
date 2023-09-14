using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelFeatureParameters : RequestParameters
    {
        public int Fk_HotelFeatureCategory { get; set; }
    }

    public class HotelFeatureModel : AuditLookUpEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(Name))]
        public new string Name { get; set; }

        [DisplayName(nameof(HotelFeatureCategory))]
        [ForeignKey(nameof(HotelFeatureCategory))]
        public int Fk_HotelFeatureCategory { get; set; }

        [DisplayName(nameof(HotelFeatureCategory))]
        public HotelFeatureCategoryModel HotelFeatureCategory { get; set; }
    }
}
