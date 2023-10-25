using Entities.CoreServicesModels.BookingModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.BookingModels;
using Entities.DBModels.HotelModels;

namespace Portal.Areas.BookingEntity.Models;

public class BookingFilter : DtParameters
{

}
public class BookingDto : BookingModel
{
    [DisplayName(nameof(FromDate))]
    public new string FromDate { get; set; }
    
    [DisplayName(nameof(ToDate))]
    public new string ToDate { get; set; }
    
    [DisplayName(nameof(CreatedAt))]
    public new string CreatedAt { get; set; }
}

public class BookingCreateOrEditModel : BaseBookingCreateOrEditModel
{
    //
}