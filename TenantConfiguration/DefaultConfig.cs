using Entities.TenantModels;
using static Entities.EnumData.DBModelsEnum;
using static TenantConfiguration.TenantData;

namespace TenantConfiguration
{
    public class TenantConfig
    {
        private List<SwaggerModel> _swaggerPages;
        private List<DashboardViewEnum> _dashboardViews;

        public TenantConfig(TenantEnvironments tenant)
        {
            Tenant = tenant;
            SetSettings(tenant);
        }

        public TenantEnvironments Tenant { get; }

        public string AppSettings { get; private set; }

        public List<SwaggerModel> SwaggerPages
        {
            get
            {
                if (_swaggerPages == null || !_swaggerPages.Any())
                {
                    SetSwaggerPages(Tenant);
                }
                return _swaggerPages;
            }
        }

        public List<DashboardViewEnum> DashboardViews
        {
            get
            {
                if (_dashboardViews == null || !_dashboardViews.Any())
                {
                    SetDashboardViews(Tenant);
                }
                return _dashboardViews;
            }
        }

        public void SetSettings(TenantEnvironments tenant)
        {
            string tenantString = tenant.ToString();

            if (tenantString.Contains('_'))
            {
                tenantString = tenantString.Replace('_', '.');
            }
            AppSettings = "appsettings." + tenantString.ToLower() + ".json";
        }
        public void SetSwaggerPages(TenantEnvironments tenant)
        {
            _swaggerPages = new List<SwaggerModel>();

            foreach (string api in Enum.GetNames(typeof(TenantApis)))
            {
                _swaggerPages.Add(new SwaggerModel
                {
                    Name = api,
                    Title = api
                });
            }
        }

        public void SetDashboardViews(TenantEnvironments tenant)
        {
            _dashboardViews = new List<DashboardViewEnum>();

            foreach (DashboardViewEnum value in Enum.GetValues(typeof(DashboardViewEnum)))
            {
                _dashboardViews.Add(value);
            }
        }
    }
}