using API.Areas.AccountArea.Models;
using Entities.CoreServicesModels.AccountModels;

namespace API.Areas.AccountArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Account")]
    [ApiExplorerSettings(GroupName = "Account")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    public class AccountController : ExtendControllerBase
    {
        public AccountController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetAccounts))]
        public async Task<IEnumerable<AccountDto>> GetAccounts([FromQuery] AccountParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<AccountModel> accounts = await _unitOfWork.Account.GetAccountsPaged(parameters, language);

            SetPagination(accounts.MetaData, parameters);

            List<AccountDto> accountsDto = _mapper.Map<List<AccountDto>>(accounts);

            return accountsDto;
        }

    }
}
