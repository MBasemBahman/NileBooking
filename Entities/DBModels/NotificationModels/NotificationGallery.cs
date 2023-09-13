namespace Entities.DBModels.NotificationModels
{
    public class NotificationGallery : ImageEntity
    {
        [DisplayName(nameof(Notification))]
        [ForeignKey(nameof(Notification))]
        public int Fk_Notification { get; set; }

        [DisplayName(nameof(Notification))]
        public Notification Notification { get; set; }
    }
}
