using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CoreServicesModels.LocationModels
{
    public class CountryParameters : RequestParameters
    {

    }
    public class CountryModel : AuditLookUpEntity
    {
        [DisplayName(nameof(HotelsCount))] 
        public int HotelsCount { get; set; }
    }
}
