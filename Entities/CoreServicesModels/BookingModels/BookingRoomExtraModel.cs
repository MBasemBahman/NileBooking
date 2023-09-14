using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.BookingModels;
using Entities.DBModels.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CoreServicesModels.BookingModels
{
    public class BookingRoomExtraParameters : RequestParameters
    {
        public int Fk_BookingRoom { get; set; }
        public int Fk_HotelExtra { get; set; }

    }
    public class BookingRoomExtraModel : BaseEntity
    {
        [DisplayName(nameof(BookingRoom))]
        [ForeignKey(nameof(BookingRoom))]
        public int Fk_BookingRoom { get; set; }

        [DisplayName(nameof(BookingRoom))]
        public BookingRoomModel BookingRoom { get; set; }

        [DisplayName(nameof(HotelExtra))]
        [ForeignKey(nameof(HotelExtra))]
        public int Fk_HotelExtra { get; set; }

        [DisplayName(nameof(HotelExtra))]
        public HotelExtraPriceModel HotelExtra { get; set; }

        [DisplayName(nameof(Price))]
        public double Price { get; set; }
    }
}
