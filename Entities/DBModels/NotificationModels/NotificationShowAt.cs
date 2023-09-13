namespace Entities.DBModels.NotificationModels
{
    public class NotificationShowAt : AuditEntity
    {
        [DisplayName(nameof(Notification))]
        [ForeignKey(nameof(Notification))]
        public int Fk_Notification { get; set; }

        [DisplayName(nameof(Notification))]
        public Notification Notification { get; set; }

        [DisplayName(nameof(NotificationType))]
        [ForeignKey(nameof(NotificationType))]
        public int Fk_NotificationType { get; set; }

        [DisplayName(nameof(NotificationType))]
        public NotificationType NotificationType { get; set; }

        [DisplayName(nameof(ExpireAt))]
        [DataType(DataType.DateTime, ErrorMessage = "{0} not valid")]
        public DateTime? ExpireAt { get; set; }

        [DisplayName(nameof(ExpireAt))]
        [NotMapped]
        public string ExpireAtString => ExpireAt != null ? ExpireAt.Value.AddHours(3).ToString("dd/MM/yyyy h:mm tt") : "-";
        
        [DisplayName(nameof(IsActive))]
        public bool IsActive { get; set; }
    }
}
