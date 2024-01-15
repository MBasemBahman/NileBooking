using System.ComponentModel;
using Entities.CoreServicesModels.FavouriteModels;

namespace API.Areas.FavouriteArea.Models
{
    public class FavouriteAccountHotelDto : FavouriteAccountHotelModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }
    }
}
