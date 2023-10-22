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
    [DisplayName(nameof(CreatedAt))]
    public new string CreatedAt { get; set; }
}

public class BookingCreateOrEditModel
{
    [DisplayName(nameof(Account))]
    public int Fk_Account { get; set; }

    [DisplayName(nameof(Hotel))]
    public int Fk_Hotel { get; set; }

    [DisplayName(nameof(FromDate))]
    public DateTime FromDate { get; set; }

    [DisplayName(nameof(ToDate))]
    public DateTime ToDate { get; set; }

    [DisplayName(nameof(BookingState))]
    public int Fk_BookingState { get; set; }
}

