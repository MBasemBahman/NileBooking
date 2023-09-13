using Entities.DBModels.AccountModels;

namespace Entities.DBModels.NotificationModels
{
    public class PrivateNotificationAccount : BaseEntity
    {
        [DisplayName(nameof(Account))]
        [ForeignKey(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName(nameof(Account))]
        public Account Account { get; set; }

        [DisplayName(nameof(Notification))]
        [ForeignKey(nameof(Notification))]
        public int Fk_Notification { get; set; }

        [DisplayName(nameof(Notification))]
        public Notification Notification { get; set; }
    }
}
