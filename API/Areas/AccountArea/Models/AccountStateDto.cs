using Entities.CoreServicesModels.AccountModels;

namespace API.Areas.AccountArea.Models
{
    public class AccountStateDto : AccountStateModel
    {
        public new string CreatedAt { get; set; }
    }
}
