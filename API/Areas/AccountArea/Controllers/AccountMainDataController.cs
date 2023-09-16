using API.Areas.AccountArea.Models;
using Entities.CoreServicesModels.AccountModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.AccountArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Account")]
    [ApiExplorerSettings(GroupName = "Account")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    public class AccountMainDataController : ExtendControllerBase
    {
        public AccountMainDataController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetAccountTypes))]
        public async Task<IEnumerable<AccountTypeDto>> GetAccountTypes([FromQuery] AccountTypeParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<AccountTypeModel> data = await _unitOfWork.Account.GetAccountTypesPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<AccountTypeDto> dataDto = _mapper.Map<List<AccountTypeDto>>(data);

            return dataDto;
        }


        [HttpGet]
        [Route(nameof(GetAccountStates))]
        public async Task<IEnumerable<AccountStateDto>> GetAccountStates([FromQuery] AccountStateParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<AccountStateModel> data = await _unitOfWork.Account.GetAccountStatesPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<AccountStateDto> dataDto = _mapper.Map<List<AccountStateDto>>(data);

            return dataDto;
        }

    }
}
