namespace Portal.Middlewares
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            IRequestCultureFeature rqf = context.Features.Get<IRequestCultureFeature>();
            string culture = rqf.RequestCulture.UICulture.ToString();

            context.Items[ApiConstants.Language] = Enum.IsDefined(typeof(LanguageEnum), culture) ? Enum.Parse<LanguageEnum>(culture.ToLower()) : null;

            await _next(context);
        }
    }
}
