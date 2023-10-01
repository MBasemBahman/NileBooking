using BaseDB;
using DAL;

namespace Portal.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            _ = services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    _ = builder.SetIsOriginAllowed(origin => true)
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials()
                           .WithExposedHeaders(HeadersConstants.AuthorizationToken,
                                               HeadersConstants.AppKey,
                                               HeadersConstants.SetRefresh);
                });
            });
        }


        public static void ConfigureScopedService(this IServiceCollection services)
        {
            _ = services.AddScoped<JwtUtils>();
            _ = services.AddScoped<AuthenticationManager>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration,
            TenantConfig config)
        {
            if (config.Tenant == TenantEnvironments.Development)
            {
                _ = services.AddDbContext<BaseContext, DBContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

                _ = services.AddScoped(_ =>
                {
                    HttpContext httpContext = new HttpContextAccessor().HttpContext;

                    return new UserAuthenticatedDto
                    {
                        Name = httpContext?.Request.Cookies[ViewDataConstants.AccountName] ?? "",
                        EmailAddress = httpContext?.Request.Cookies[ViewDataConstants.AccountEmail] ?? "",
                    };
                });
            }

        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            _ = services.AddScoped<RepositoryManager, RepositoryManager>();
            _ = services.AddScoped<UnitOfWork, UnitOfWork>();
        }

        public static void ConfigureResponseCaching(this IServiceCollection services)
        {
            _ = services.AddResponseCaching();
        }


        public static void ConfigureLocalization(this IServiceCollection services)
        {
            _ = services.AddLocalization(options => options.ResourcesPath = "Resources");

            _ = services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new()
                {
                    new CultureInfo("en"),
                    new CultureInfo("ar")
                };

                foreach (string language in Enum.GetNames(typeof(LanguageEnum)))
                {
                    supportedCultures.Add(new CultureInfo(language));
                }

                options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            _ = services.AddSingleton<LocalizationManager>();
        }

        public static void ConfigureViews(this IServiceCollection services)
        {
            _ = services.AddControllersWithViews()
                   .AddViewLocalization()
                   .AddDataAnnotationsLocalization(options =>
                   {
                       options.DataAnnotationLocalizerProvider = (type, factory) =>
                       {
                           AssemblyName assemblyName = new(typeof(ResourcesFile).GetTypeInfo().Assembly.FullName);
                           return factory.Create(nameof(ResourcesFile), assemblyName.Name);
                       };
                   })
                   .AddSessionStateTempDataProvider()
                   .AddRazorRuntimeCompilation()
                   .AddNewtonsoftJson(options =>
                   {
                       options.SerializerSettings.Converters.Add(new StringEnumConverter());
                   });
        }

        public static void ConfigureSessionAndCookie(this IServiceCollection services)
        {
            _ = services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
                options.IOTimeout = TimeSpan.FromMinutes(5);

                options.Cookie.Name = ".dashboard.cookie";
                options.Cookie.MaxAge = TimeSpan.FromDays(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            });

            _ = services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });

            _ = services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
