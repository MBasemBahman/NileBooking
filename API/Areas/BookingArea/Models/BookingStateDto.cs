using Entities.CoreServicesModels.BookingModels;

namespace API.Areas.BookingArea.Models
{
    public class BookingStateDto : BookingStateModel
    {
        public new string CreatedAt { get; set; }
    }
}
