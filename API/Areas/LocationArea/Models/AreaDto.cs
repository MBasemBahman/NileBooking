using Entities.CoreServicesModels.LocationModels;
using System.ComponentModel;

namespace API.Areas.LocationArea.Models
{
    public class AreaDto : AreaModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

        [DisplayName(nameof(Country))]
        public new CountryDto Country { get; set; }
    }
}
