using Entities.EnumData;

namespace Entities.DBModels.NotificationModels
{
    public class NotificationOpenType : LookUpEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }
        
        
        [DisplayName(nameof(Notifications))]
        public List<Notification> Notifications { get; set; }
        
        public List<NotificationOpenTypeLang> NotificationOpenTypeLangs { get; set; }
    }
    
    public class NotificationOpenTypeLang : AuditLangEntity<NotificationOpenType>
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }
    }
}
