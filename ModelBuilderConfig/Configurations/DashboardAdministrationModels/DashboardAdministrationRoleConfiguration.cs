using Entities.DBModels.AccountModels;
using Entities.DBModels.DashboardAdministrationModels;

namespace ModelBuilderConfig.Configurations.DashboardAdministrationModels
{
    public class DashboardAdministrationRoleConfiguration : IEntityTypeConfiguration<DashboardAdministrationRole>
    {
        public void Configure(EntityTypeBuilder<DashboardAdministrationRole> builder)
        {
            _ = builder.HasData(new DashboardAdministrationRole
            {
                Id = (int)DashboardAdministrationRoleEnum.Developer,
                Name = DashboardAdministrationRoleEnum.Developer.ToString()
            });
        }
    }

    public class DashboardAdministrationRoleLangConfiguration : IEntityTypeConfiguration<DashboardAdministrationRoleLang>
    {
        public void Configure(EntityTypeBuilder<DashboardAdministrationRoleLang> builder)
        {
            int index = 1;
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                _ = builder.HasData(new DashboardAdministrationRoleLang
                {
                    Id = index++,
                    Name = DashboardAdministrationRoleEnum.Developer.ToString(),
                    Fk_Source = (int)DashboardAdministrationRoleEnum.Developer,
                    Language = language
                });
            }
        }
    }
}
