using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers
{
    public class ExtendControllerBase : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly AuthenticationManager _authManager;
        protected readonly UnitOfWork _unitOfWork;
        protected readonly IWebHostEnvironment _environment;
        protected readonly LocalizationManager _localizer;

        public ExtendControllerBase(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer)
        {
            _mapper = mapper;
            _authManager = authManager;
            _unitOfWork = unitOfWork;
            _environment = environment;
            _localizer = localizer;
        }
        // Helper Methods
        protected string GetExceptionMsg(string exceptionMsg)
        {
            exceptionMsg = exceptionMsg.Length > 150 ? _localizer.Get("Something error, please try again!") : _localizer.Get(exceptionMsg);
            return exceptionMsg;
        }
    }

  

}
