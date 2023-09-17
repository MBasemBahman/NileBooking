using AspNetCoreRateLimit;
using Entities.TenantModels;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;
using Repository;
using Services;
using System.Globalization;
using System.Reflection;
using TenantConfiguration;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {

            _ = services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    _ = builder.SetIsOriginAllowed(a => true)
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials()
                           .WithExposedHeaders(HeadersConstants.Status,
                                               HeadersConstants.Pagination,
                                               HeadersConstants.Authorization,
                                               HeadersConstants.Expires,
                                               HeadersConstants.SetRefresh);
                });
            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            _ = services.AddSingleton<ResponseManager>();
        }

        public static void ConfigureScopedService(this IServiceCollection services)
        {
            _ = services.AddScoped<JwtUtils>();
            _ = services.AddScoped<AuthenticationManager>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration,
            TenantConfig tenant)
        {
            if (tenant.Tenant == TenantEnvironments.Development)
            {
                _ = services.AddDbContext<BaseContext, DBContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                                                                options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            }
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            _ = services.AddScoped<RepositoryManager>();
            _ = services.AddScoped<UnitOfWork>();
        }

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            _ = services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            _ = services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }

        public static void ConfigureResponseCaching(this IServiceCollection services)
        {
            _ = services.AddResponseCaching();
        }

        public static void ConfigureSwagger(this IServiceCollection services, TenantConfig tenant)
        {
            _ = services.AddSwaggerGen(c =>
            {
                c.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("hh:mm:ss")
                });

                c.MapType<DateTime>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("yyyy-MM-ddThh:mm:ss")
                });

                foreach (SwaggerModel page in tenant.SwaggerPages)
                {
                    c.SwaggerDoc(page.Name, new OpenApiInfo { Title = page.Title });
                }

                c.OperationFilter<DocsFilter>();

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void ConfigureLocalization(this IServiceCollection services)
        {
            _ = services.AddLocalization(options => options.ResourcesPath = "Resources");

            _ = services.Configure<RequestLocalizationOptions>(options =>
            {
                CultureInfo[] supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("ar")
                };
                options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            _ = services.AddSingleton<LocalizationManager>();
        }

        public static void ConfigureRequestsLimit(this IServiceCollection services)
        {
            // needed to store rate limit counters and ip rules
            _ = services.AddMemoryCache();

            _ = services.Configure<IpRateLimitOptions>(options =>
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-IP";
                options.ClientIdHeader = "X-ClientId";
                options.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Period = "1s",
                        Limit = 100,
                    }
                };
            });

            _ = services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            _ = services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            _ = services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            _ = services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
            _ = services.AddInMemoryRateLimiting();
        }

        public static void ConfigureFirebase(this IServiceCollection services,
          string appSettingsFile)
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, appSettingsFile)));

            _ = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromJson(jAppSettings["GoogleCredential"].ToString())
            });

            _ = services.AddScoped<FirebaseNotificationManager>();
        }
    }
}
