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

            if (Enum.IsDefined(typeof(LanguageEnum), culture))
            {
                context.Items[ApiConstants.Language] = Enum.Parse<LanguageEnum>(culture.ToLower());
            }
            else
            {
                context.Items[ApiConstants.Language] = null;
            }

            await _next(context);
        }
    }
}
