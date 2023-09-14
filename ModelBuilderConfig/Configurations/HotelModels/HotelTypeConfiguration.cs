using Entities.DBModels.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBuilderConfig.Configurations.HotelModels
{
    public class HotelTypeConfiguration : IEntityTypeConfiguration<HotelType>
    {
        public void Configure(EntityTypeBuilder<HotelType> builder)
        {
            foreach (HotelTypeEnum value in Enum.GetValues(typeof(HotelTypeEnum)))
            {
                _ = builder.HasData(new HotelType
                {
                    Id = (int)value,
                    Name = value.ToString()
                });
            }
        }
    }

    public class HotelTypeLangConfiguration : IEntityTypeConfiguration<HotelTypeLang>
    {
        public void Configure(EntityTypeBuilder<HotelTypeLang> builder)
        {
            int index = 1;
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                foreach (HotelTypeEnum value in Enum.GetValues(typeof(HotelTypeEnum)))
                {
                    _ = builder.HasData(new HotelTypeLang
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
