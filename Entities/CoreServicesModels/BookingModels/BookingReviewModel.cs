using Entities.DBModels.BookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CoreServicesModels.BookingModels
{
    public class BookingReviewParameters : RequestParameters
    {
        public int Fk_Booking { get; set; }

    }
    public class BookingReviewModel : BaseEntity
    {
        [DisplayName(nameof(Booking))]
        [ForeignKey(nameof(Booking))]
        public int Fk_Booking { get; set; }

        [DisplayName(nameof(Booking))]
        public BookingModel Booking { get; set; }

        [DisplayName(nameof(Description))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName(nameof(Rate))]
        public double Rate { get; set; } = 5.0;
    }
}
