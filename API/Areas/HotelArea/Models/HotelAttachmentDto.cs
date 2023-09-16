using Entities.CoreServicesModels.HotelModels;
using System.ComponentModel;

namespace API.Areas.HotelArea.Models
{
    public class HotelAttachmentDto : HotelAttachmentModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

        [DisplayName(nameof(Hotel))]
        public new HotelDto Hotel { get; set; }
    }
}
