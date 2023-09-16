using API.Areas.HotelRoomArea.Models;
using API.Areas.LocationArea.Models;
using Entities.CoreServicesModels.HotelModels;
using System.ComponentModel;

namespace API.Areas.HotelArea.Models
{
    public class HotelDto : HotelModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

        [DisplayName(nameof(HotelType))]
        public new HotelTypeDto HotelType { get; set; }

        [DisplayName(nameof(Area))]
        public new AreaDto Area { get; set; }

        [DisplayName("HotelFeatures")]
        public new List<HotelSelectedFeaturesWithCategoryDto> HotelSelectedFeatures { get; set; }


        [DisplayName(nameof(HotelExtras))]
        public new List<HotelExtraPriceDto> HotelExtras { get; set; }

        [DisplayName(nameof(HotelRooms))]
        public new List<HotelRoomDto> HotelRooms { get; set; }

        [DisplayName(nameof(HotelAttachments))]
        public new List<HotelAttachmentDto> HotelAttachments { get; set; }

    }
}
