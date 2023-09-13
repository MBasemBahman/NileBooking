using Entities.DBModels.BookingModels;
using Entities.EnumData;

namespace Entities.DBModels.HotelModels;

public class HotelReview : BaseEntity
{
    [DisplayName(nameof(Booking))]
    [ForeignKey(nameof(Booking))]
    public int Fk_Booking { get; set; }

    [DisplayName(nameof(Booking))]
    public Booking Booking { get; set; }

    [DisplayName(nameof(Description))]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; }
    
    [DisplayName(nameof(Rate))]
    public double Rate { get; set; }
}