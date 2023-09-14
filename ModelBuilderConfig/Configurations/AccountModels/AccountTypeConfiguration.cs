using Entities.DBModels.AccountModels;

namespace ModelBuilderConfig.Configurations.AccountModels
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            foreach (AccountTypeEnum value in Enum.GetValues(typeof(AccountTypeEnum)))
            {
                _ = builder.HasData(new AccountType
                {
                    Id = (int)value,
                    Name = value.ToString()
                });
            }
        }
    }

    public class AccountTypeLangConfiguration : IEntityTypeConfiguration<AccountTypeLang>
    {
        public void Configure(EntityTypeBuilder<AccountTypeLang> builder)
        {
            int index = 1;
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                foreach (AccountTypeEnum value in Enum.GetValues(typeof(AccountTypeEnum)))
                {
                    _ = builder.HasData(new AccountTypeLang
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
