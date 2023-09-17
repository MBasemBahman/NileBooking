using API.Extensions;
using API.MappingProfileCls;
using API.Middlewares;
using AspNetCoreRateLimit;
using TenantConfiguration;

TenantConfig config = new(TenantEnvironments.Development);

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile(config.AppSettings);

// Add services to the container
builder.Services.ConfigureRequestsLimit();
builder.Services.ConfigureCors();
builder.Services.AddSignalR();
builder.Services.AddHttpClient();
builder.Services.ConfigureLoggerService();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile(provider.GetService<IOptions<AppSettings>>()));
}).CreateMapper());
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureLocalization();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureScopedService();
builder.Services.ConfigureSqlContext(builder.Configuration, config);
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.ConfigureSwagger(config);

builder.Services.AddControllersWithViews(opt =>
{
    _ = opt.Filters.Add(typeof(GlobalModelStateValidatorAttribute));
});

//builder.Services.ConfigureFirebase(config.AppSettings);

WebApplication app = builder.Build();
app.UseIpRateLimiting();

ResponseManager logger = app.Services.GetRequiredService<ResponseManager>();
LocalizationManager localizer = app.Services.GetRequiredService<LocalizationManager>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();
app.ConfigureStaticFiles();
app.UseFileServer();
app.UseCors();
app.ConfigureSwagger(config);
app.UseResponseCaching();
app.UseRequestLocalization(app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value);

app.UseMiddleware<BodyBufferingMiddleware>();
app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<CultureMiddleware>();
app.UseMiddleware<HeaderMiddleware>();
app.ConfigureExceptionHandler(logger);

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();
