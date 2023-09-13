using Entities.DBModels.AccountModels;
using Entities.DBModels.HotelModels;
using Entities.DBModels.PromoCodeModels;

namespace Entities.DBModels.BookingModels;

public class Booking : AuditImageEntity
{
    [DisplayName(nameof(Account))]
    [ForeignKey(nameof(Account))]
    public int Fk_Account { get; set; }

    [DisplayName(nameof(Account))]
    public Account Account { get; set; }
    
    [DisplayName(nameof(Hotel))]
    [ForeignKey(nameof(Hotel))]
    public int Fk_Hotel { get; set; }

    [DisplayName(nameof(Hotel))]
    public Hotel Hotel { get; set; }
    
    [DisplayName(nameof(FromDate))]
    public DateTime FromDate { get; set; }
    
    [DisplayName(nameof(ToDate))]
    public DateTime ToDate { get; set; }
    
    [DisplayName(nameof(BookingState))]
    [ForeignKey(nameof(BookingState))]
    public int Fk_BookingState { get; set; }

    [DisplayName(nameof(BookingState))]
    public BookingState BookingState { get; set; }
    
    [DisplayName(nameof(TotalRoomPrice))]
    public double TotalRoomPrice { get; set; }
    
    [DisplayName(nameof(TotalExtraPrice))]
    public double TotalExtraPrice { get; set; }
    
    [DisplayName(nameof(Fees))]
    public double Fees { get; set; }

    [DisplayName(nameof(FinalPrice))] 
    public double FinalPrice => TotalRoomPrice + TotalExtraPrice + Fees - Discount;

    [DisplayName(nameof(PromoCode))]
    [ForeignKey(nameof(PromoCode))]
    public int? Fk_PromoCode { get; set; }

    [DisplayName(nameof(PromoCode))]
    public PromoCode PromoCode { get; set; }

    [DisplayName(nameof(Discount))]
    public double Discount { get; set; }
}