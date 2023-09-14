using Entities.DBModels.DashboardAdministrationModels;

namespace ModelBuilderConfig.Configurations.DashboardAdministrationModels
{
    public class DashboardViewConfiguration : IEntityTypeConfiguration<DashboardView>
    {
        private readonly List<DashboardViewEnum> _dashboardViews;
        public DashboardViewConfiguration(List<DashboardViewEnum> dashboardViews)
        {
            _dashboardViews = dashboardViews;
        }

        public void Configure(EntityTypeBuilder<DashboardView> builder)
        {
            foreach (DashboardViewEnum value in _dashboardViews)
            {
                _ = builder.HasData(new DashboardView
                {
                    Id = (int)value,
                    Name = value.ToString(),
                    ViewPath = value.ToString()
                });
            }
        }
    }
}
