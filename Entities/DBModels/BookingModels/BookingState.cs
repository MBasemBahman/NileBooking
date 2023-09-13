using Entities.EnumData;

namespace Entities.DBModels.BookingModels
{
    public class BookingState : LookUpEntity, IColorEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }
        
        [DisplayName(nameof(Bookings))]
        public List<Booking> Bookings { get; set; }

        public List<BookingStateLang> BookingStateLangs { get; set; }
    }

    public class BookingStateLang : AuditLangEntity<BookingState>
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }
    }
}
