using Entities.CoreServicesModels.LocationModels;

namespace API.Areas.LocationArea.Models
{
    public class CountryDto : CountryModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }
    }
}
