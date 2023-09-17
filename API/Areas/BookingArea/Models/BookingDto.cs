using Entities.CoreServicesModels.BookingModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using API.Areas.AccountArea.Models;
using API.Areas.HotelArea.Models;

namespace API.Areas.BookingArea.Models
{ 
    public class BookingDto : BookingModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

        [DisplayName(nameof(Account))]
        public new AccountDto Account { get; set; }

        [DisplayName(nameof(Hotel))]
        public new HotelDto Hotel { get; set; }

        [DisplayName(nameof(FromDate))]
        public new string FromDate { get; set; }

        [DisplayName(nameof(ToDate))]
        public new string ToDate { get; set; }

        [DisplayName(nameof(BookingState))]
        public new BookingStateDto BookingState { get; set; }

        [DisplayName(nameof(BookingReview))]
        public new BookingReviewDto BookingReview { get; set; }

        [DisplayName(nameof(BookingRooms))]
        public new List<BookingRoomDto> BookingRooms { get; set; }
    }

    public class BookingCreateDto
    {
        public int Fk_Hotel { get; set; }
     
        [DisplayName(nameof(Fees))]
        public double Fees { get; set; }

        [DisplayName(nameof(Discount))]
        public double Discount { get; set; }

        public List<BookingRoomCreateDto> BookingRooms { get; set; }
    }

    public class BookingEditDto
    {
        [DisplayName(nameof(FromDate))]
        public DateTime FromDate { get; set; }

        [DisplayName(nameof(ToDate))]
        public DateTime ToDate { get; set; }
    }
}
