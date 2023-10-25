using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.BookingModels;
using Entities.DBModels.HotelModels;

namespace Entities.CoreServicesModels.BookingModels
{
    public class BookingParameters : RequestParameters
    {
        public int Fk_Account { get; set; }

        public int Fk_Hotel { get; set; }

        public int Fk_BookingState { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public bool IncludeReview { get; set; } = false;
        public bool IncludeRooms { get; set; } = false;

    }
    public class BookingModel : AuditImageEntity
    {
        [DisplayName(nameof(Account))]
        [ForeignKey(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName(nameof(Account))]
        public AccountModel Account { get; set; }

        [DisplayName(nameof(Hotel))]
        [ForeignKey(nameof(Hotel))]
        public int Fk_Hotel { get; set; }

        [DisplayName(nameof(Hotel))]
        public HotelModel Hotel { get; set; }
        
        [DisplayName(nameof(CanCancel))]
        public bool CanCancel { get; set; }

        [DisplayName(nameof(FromDate))]
        public DateTime FromDate { get; set; }

        [DisplayName(nameof(ToDate))]
        public DateTime ToDate { get; set; }

        [DisplayName(nameof(BookingState))]
        [ForeignKey(nameof(BookingState))]
        public int Fk_BookingState { get; set; }

        [DisplayName(nameof(BookingState))]
        public BookingStateModel BookingState { get; set; }

        [DisplayName(nameof(TotalRoomPrice))]
        public double TotalRoomPrice { get; set; }

        [DisplayName(nameof(TotalExtraPrice))]
        public double TotalExtraPrice { get; set; }

        [DisplayName(nameof(Fees))]
        public double Fees { get; set; }

        [DisplayName(nameof(Discount))]
        public double Discount { get; set; }

        [DisplayName(nameof(FinalPrice))]
        public double FinalPrice => TotalRoomPrice + TotalExtraPrice + Fees - Discount;

        [DisplayName(nameof(TotalBookingRoomsAdultCount))]
        public int TotalBookingRoomsAdultCount { get; set; }
        
        [DisplayName(nameof(TotalBookingRoomsChildCount))]
        public int TotalBookingRoomsChildCount { get; set; }
        
        [DisplayName(nameof(BookingReview))]
        public BookingReviewModel BookingReview { get; set; }
        
        [DisplayName(nameof(BookingRooms))]
        public List<BookingRoomModel> BookingRooms { get; set; }

    }

    public class BookingCreateModel
    {
        public int Fk_Hotel { get; set; }

        [DisplayName(nameof(Fees))]
        public double Fees { get; set; }

        [DisplayName(nameof(Discount))]
        public double Discount { get; set; }

        [DisplayName(nameof(FromDate))]
        public DateTime FromDate { get; set; }

        [DisplayName(nameof(ToDate))]
        public DateTime ToDate { get; set; }
        
        [DisplayName(nameof(AdultCount))]
        public int AdultCount { get; set; }

        [DisplayName(nameof(ChildCount))]
        public int ChildCount { get; set; }
        
        public List<int> Fk_RoomTypes { get; set; }
        public List<BookingRoomCreateModel> BookingRooms { get; set; }
    }

    public class BaseBookingCreateOrEditModel
    {
        [DisplayName(nameof(Account))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public int Fk_Account { get; set; }

        [DisplayName(nameof(Hotel))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public int Fk_Hotel { get; set; }

        [DisplayName(nameof(Fees))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public double Fees { get; set; }

        [DisplayName(nameof(Discount))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public double Discount { get; set; }
    
        [DisplayName(nameof(FromDate))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public DateTime FromDate { get; set; }

        [DisplayName(nameof(ToDate))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public DateTime ToDate { get; set; }

        [DisplayName(nameof(BookingState))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public int Fk_BookingState { get; set; }
        
        [DisplayName(nameof(AdultCount))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public int AdultCount { get; set; }
        
        [DisplayName(nameof(ChildCount))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public int ChildCount { get; set; }
        
        [DisplayName(nameof(BookingRooms))]
        public List<BookingRoomCreateOrEditModel> BookingRooms { get; set; }
    }

}
