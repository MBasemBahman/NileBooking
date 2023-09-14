using Entities.DBModels.BookingModels;

namespace ModelBuilderConfig.Configurations.BookingModels
{
    public class BookingStateConfiguration : IEntityTypeConfiguration<BookingState>
    {
        public void Configure(EntityTypeBuilder<BookingState> builder)
        {
            foreach (BookingStateEnum value in Enum.GetValues(typeof(BookingStateEnum)))
            {
                _ = builder.HasData(new BookingState
                {
                    Id = (int)value,
                    Name = value.ToString()
                });
            }
        }
    }

    public class BookingStateLangConfiguration : IEntityTypeConfiguration<BookingStateLang>
    {
        public void Configure(EntityTypeBuilder<BookingStateLang> builder)
        {
            int index = 1;
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                foreach (BookingStateEnum value in Enum.GetValues(typeof(BookingStateEnum)))
                {
                    _ = builder.HasData(new BookingStateLang
                    {
                        Id = index++,
                        Fk_Source = (int)value,
                        Name = value.ToString(),
                        Language = language
                    });
                }
            }
        }
    }
}
