namespace Entities.DBModels.NotificationModels
{
    public class Notification : ImageEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(Title))]
        public string Title { get; set; }

        [DisplayName(nameof(Description))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName(nameof(LongDescription))]
        [DataType(DataType.MultilineText)]
        public string LongDescription { get; set; }

        [DisplayName(nameof(ScheduleJobID))]
        public string ScheduleJobID { get; set; }

        [DisplayName(nameof(NotificationType))]
        [ForeignKey(nameof(NotificationType))]
        public int? Fk_NotificationType { get; set; }

        [DisplayName(nameof(NotificationType))]
        public NotificationType NotificationType { get; set; }

        [DisplayName(nameof(NotificationOpenType))]
        [ForeignKey(nameof(NotificationOpenType))]
        public int Fk_NotificationOpenType { get; set; }

        [DisplayName(nameof(NotificationOpenType))]
        public NotificationOpenType NotificationOpenType { get; set; }

        [DisplayName(nameof(OpenTypeValue))]
        public string OpenTypeValue { get; set; }

        [DisplayName(nameof(ViewCount))]
        public int ViewCount { get; set; } = 0;

        [DisplayName(nameof(ShowAt))]
        [DataType(DataType.DateTime, ErrorMessage = "{0} not valid")]
        public DateTime ShowAt { get; set; } = DateTime.UtcNow.AddHours(3);

        [DisplayName(nameof(ShowAt))]
        [NotMapped]
        public string ShowAtString => ShowAt.ToString("dd/MM/yyyy h:mm tt");

        [DisplayName(nameof(NotificationGallery))]
        public List<NotificationGallery> NotificationGallery { get; set; }

        [DisplayName(nameof(NotificationShowAt))]
        public List<NotificationShowAt> NotificationShowAt { get; set; }

        [DisplayName(nameof(NotificationAccounts))]
        public List<NotificationAccount> NotificationAccounts { get; set; }

        [DisplayName(nameof(PrivateNotificationAccounts))]
        public List<PrivateNotificationAccount> PrivateNotificationAccounts { get; set; }
    }
}
