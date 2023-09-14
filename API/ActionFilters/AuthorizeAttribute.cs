namespace API.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAllAttribute>().Any())
            {
                return;
            }

            if (!context.ActionDescriptor.EndpointMetadata.OfType<AllowDebugAttribute>().Any())
            {
                string appKey = context.HttpContext.Request.Headers[HeadersConstants.AppKey];

                IServiceProvider services = context.HttpContext.RequestServices;
                AppSettings _appSettings = services.GetService<IOptions<AppSettings>>().Value;

                if (string.IsNullOrEmpty(appKey))
                {
                    context.Result = new BadRequestResult();
                    return;
                }
                else if (appKey != _appSettings.AppKey)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }

            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
            {
                return;
            }

            UserAuthenticatedDto account = (UserAuthenticatedDto)context.HttpContext.Items[ApiConstants.User];
            if (account == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
