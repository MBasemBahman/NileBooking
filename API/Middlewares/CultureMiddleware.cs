namespace API.Middlewares
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
            string culture = context.Request.Headers[HeadersConstants.Culture].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrWhiteSpace(culture))
            {
                culture = "en";
            }

            context.Items[ApiConstants.Language] = Enum.IsDefined(typeof(LanguageEnum), culture) ? Enum.Parse<LanguageEnum>(culture.ToLower()) : null;

            await _next(context);
        }
    }
}
