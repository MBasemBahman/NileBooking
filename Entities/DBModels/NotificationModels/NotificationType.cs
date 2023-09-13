using Entities.EnumData;

namespace Entities.DBModels.NotificationModels
{
    public class NotificationType : LookUpEntity, IColorEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }

        public List<NotificationTypeLang> NotificationTypeLangs { get; set; }
        
        [DisplayName(nameof(NotificationShowAt))]
        public List<NotificationShowAt> NotificationShowAt { get; set; }
    }
    
    public class NotificationTypeLang : AuditLangEntity<NotificationType>
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }
    }
}
