using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
