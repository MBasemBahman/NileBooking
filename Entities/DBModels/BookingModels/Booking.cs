﻿using Entities.DBModels.AccountModels;
using Entities.DBModels.HotelModels;

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

    [DisplayName(nameof(Discount))]
    public double Discount { get; set; }

    [DisplayName(nameof(AdultCount))]
    public int AdultCount { get; set; }

    [DisplayName(nameof(ChildCount))]
    public int ChildCount { get; set; }

    [DisplayName(nameof(TotalAdultPrice))]
    public double TotalAdultPrice { get; set; }

    [DisplayName(nameof(TotalChildPrice))]
    public double TotalChildPrice { get; set; }
    
    [DisplayName(nameof(FinalPrice))]
    public double FinalPrice => TotalRoomPrice + TotalExtraPrice + Fees - Discount;

    [DisplayName(nameof(BookingReview))]
    public BookingReview BookingReview { get; set; }

    [DisplayName(nameof(BookingRooms))]
    public List<BookingRoom> BookingRooms { get; set; }
}