namespace API.Middlewares
{
    public class HeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public HeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add(HeadersConstants.Status, new Response(true).ToString());
            await _next.Invoke(context);
        }
    }
}
