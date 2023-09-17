using API.Areas.AccountArea.Models;
using Entities.CoreServicesModels.BookingModels;
using System.ComponentModel;

namespace API.Areas.BookingArea.Models
{
    public class BookingReviewDto : BookingReviewModel
    {
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(Account))]
        public new AccountDto Account { get; set; }

    }
}
