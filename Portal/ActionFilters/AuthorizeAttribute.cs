using Portal.Models;

namespace Portal.ActionFilters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly DashboardViewEnum _viewEnum;
        private readonly DashboardAccessLevelEnum _accessLevel;
        private readonly UnitOfWork _unitOfWork;

        public AuthorizationFilter(
            DashboardViewEnum viewEnum,
            DashboardAccessLevelEnum accessLevel,
            UnitOfWork unitOfWork)
        {
            _viewEnum = viewEnum;
            _accessLevel = accessLevel;
            _unitOfWork = unitOfWork;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAllAttribute>().Any())
            {
                return;
            }

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

            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
            {
                return;
            }

            UserAuthenticatedDto auth = (UserAuthenticatedDto)context.HttpContext.Items[ApiConstants.User];
            if (auth == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Authentication", action = "Login", area = "Dashboard" }));
                return;
            }

            if (_viewEnum != DashboardViewEnum.Home)
            {
                DashboardAccessLevelModel accessLevel = _unitOfWork.DashboardAdministration.GetAccessLevelByPremission(new DashboardAccessLevelParameters
                {
                    Fk_DashboardView = (int)_viewEnum,
                    Fk_DashboardAdministrationRole = auth.Fk_DashboardAdministrationRole
                });

                if (!(accessLevel != null &&
                     ((_accessLevel == DashboardAccessLevelEnum.Viewer && accessLevel.ViewAccess) ||
                      (_accessLevel == DashboardAccessLevelEnum.DataControl && accessLevel.CreateAccess && accessLevel.EditAccess) ||
                      (_accessLevel == DashboardAccessLevelEnum.FullAccess && accessLevel.DeleteAccess))))
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", area = "Dashboard" }));
                    return;
                }

                context.HttpContext.Items[ViewDataConstants.AccessLevel] = accessLevel;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(
            DashboardViewEnum viewEnum,
            DashboardAccessLevelEnum accessLevel)
            : base(typeof(AuthorizationFilter))
        {
            Arguments = new object[] { viewEnum, accessLevel };
        }

        public AuthorizeAttribute(
            DashboardViewEnum viewEnum)
            : base(typeof(AuthorizationFilter))
        {
            Arguments = new object[] { viewEnum, DashboardAccessLevelEnum.Viewer };
        }

        public AuthorizeAttribute()
            : base(typeof(AuthorizationFilter))
        {
            Arguments = new object[] { DashboardViewEnum.Home, DashboardAccessLevelEnum.Viewer };
        }
    }
}
