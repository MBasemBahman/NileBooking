namespace API.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, AuthenticationManager authService, JwtUtils jwtUtils)
        {
            string token = context.Request.Headers[HeadersConstants.AuthorizationToken].FirstOrDefault()?.Split(" ").Last();
            if (!string.IsNullOrWhiteSpace(token))
            {
                int? accountId = jwtUtils.ValidateJwtToken(token);
                if (accountId != null)
                {
                    // attach account to context on successful jwt validation
                    context.Items[ApiConstants.User] = await authService.GetById(accountId.Value);
                    context.Items[HeadersConstants.AuthorizationToken] = token;
                }
            }

            await _next(context);
        }
    }
}
