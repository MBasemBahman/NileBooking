using Entities.DBModels.HotelRoomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBuilderConfig.Configurations.HotelRoomModels
{
    public class RoomFoodTypeConfiguration : IEntityTypeConfiguration<RoomFoodType>
    {
        public void Configure(EntityTypeBuilder<RoomFoodType> builder)
        {
            foreach (RoomFoodTypeEnum value in Enum.GetValues(typeof(RoomFoodTypeEnum)))
            {
                _ = builder.HasData(new RoomFoodType
                {
                    Id = (int)value,
                    Name = value.ToString()
                });
            }
        }
    }

    public class RoomFoodTypeLangConfiguration : IEntityTypeConfiguration<RoomFoodTypeLang>
    {
        public void Configure(EntityTypeBuilder<RoomFoodTypeLang> builder)
        {
            int index = 1;
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                foreach (RoomFoodTypeEnum value in Enum.GetValues(typeof(RoomFoodTypeEnum)))
                {
                    _ = builder.HasData(new RoomFoodTypeLang
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
