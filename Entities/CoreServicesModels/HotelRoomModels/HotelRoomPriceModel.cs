using Entities.DBModels.HotelRoomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CoreServicesModels.HotelRoomModels
{
    public class HotelRoomPriceParameters : RequestParameters
    {
        public int Fk_HotelRoom { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

    }

    public class HotelRoomPriceModel : BaseEntity
    {
        [DisplayName(nameof(HotelRoom))]
        [ForeignKey(nameof(HotelRoom))]
        public int Fk_HotelRoom { get; set; }

        [DisplayName(nameof(HotelRoom))]
        public HotelRoomModel HotelRoom { get; set; }

        [DisplayName(nameof(AdultPrice))]
        public double AdultPrice { get; set; }

        [DisplayName(nameof(ChildPrice))]
        public double ChildPrice { get; set; }

        [DisplayName(nameof(FromDate))]
        public DateTime FromDate { get; set; }

        [DisplayName(nameof(ToDate))]
        public DateTime ToDate { get; set; }
    }
}
