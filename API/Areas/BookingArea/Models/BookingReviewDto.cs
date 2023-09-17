using API.Areas.AccountArea.Models;
using Entities.CoreServicesModels.BookingModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Areas.BookingArea.Models
{
    public class BookingReviewDto : BookingReviewModel
    {
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(Account))]
        public new AccountDto Account { get; set; }

    }

    public class BookingReviewEditDto
    {
        [DisplayName(nameof(Description))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName(nameof(Rate))]
        public double Rate { get; set; } = 5.0;
    }
}
