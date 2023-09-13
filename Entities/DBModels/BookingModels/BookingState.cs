namespace Entities.DBModels.BookingModels
{
    public class BookingState : LookUpEntity, IColorEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }

        [DisplayName(nameof(Bookings))]
        public List<Booking> Bookings { get; set; }

        [DisplayName(nameof(BookingStateLangs))]
        public List<BookingStateLang> BookingStateLangs { get; set; }
    }

    public class BookingStateLang : AuditLangEntity<BookingState>
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }
    }
}
