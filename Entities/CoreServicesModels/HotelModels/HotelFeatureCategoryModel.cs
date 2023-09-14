using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelFeatureCategoryParameters : RequestParameters
    {
        public bool? IncludeHotelFeatures { get; set; }
    }

    public class HotelFeatureCategoryModel : AuditLookUpEntity
    {
        [DisplayName(nameof(Name))]
        public new string Name { get; set; }

        [DisplayName(nameof(HotelFeatures))]
        public int HotelFeaturesCount { get; set; }

        public List<HotelFeatureModel> HotelFeatures { get; set; }
    }

}
