using Entities.DBModels.HotelRoomModels;

namespace ModelBuilderConfig.Configurations.HotelRoomModels
{
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            foreach (RoomTypeEnum value in Enum.GetValues(typeof(RoomTypeEnum)))
            {
                _ = builder.HasData(new RoomType
                {
                    Id = (int)value,
                    Name = value.ToString()
                });
            }
        }
    }

    public class RoomTypeLangConfiguration : IEntityTypeConfiguration<RoomTypeLang>
    {
        public void Configure(EntityTypeBuilder<RoomTypeLang> builder)
        {
            int index = 1;
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                foreach (RoomTypeEnum value in Enum.GetValues(typeof(RoomTypeEnum)))
                {
                    _ = builder.HasData(new RoomTypeLang
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
