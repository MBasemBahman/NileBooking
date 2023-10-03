using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;
using Entities.Extensions;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Portal.Areas.AccountEntity.Models;
namespace Portal.Areas.AccountEntity.Controllers
{
    [Area("AccountEntity")]
    [Authorize(DashboardViewEnum.Account, DashboardAccessLevelEnum.Viewer)]
    public class AccountController : ExtendControllerBase
    {
        private readonly LinkGenerator _linkGenerator;

        public AccountController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LinkGenerator linkGenerator,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {
            _linkGenerator= linkGenerator;
        }

        public IActionResult Index(int Fk_AccountType,int Fk_AccountState)
        {
            AccountIndexViewModel model = new()
            {
                Filter = new AccountFilter()
                {
                    Fk_AccountState = Fk_AccountState,
                    Fk_AccountType =Fk_AccountType
                }
            };

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            SetViewData();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] AccountFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AccountParameters parameters = new()
            {
                SearchColumns = "Id"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<AccountModel> data = await _unitOfWork.Account.GetAccountsPaged(parameters, otherLang);

            List<AccountDto> resultDto = _mapper.Map<List<AccountDto>>(data);

            DataTable<AccountDto> dataTableManager = new();

            DataTableResult<AccountDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Account.GetAccountsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AccountDto data = _mapper.Map<AccountDto>(_unitOfWork.Account.GetAccountById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.Account, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            AccountCreateOrEditDto model = new();
            if (id > 0)
            {
                Account dataDB = await _unitOfWork.Account.FindAccountById(id, trackChanges: false);
                model = _mapper.Map<AccountCreateOrEditDto>(dataDB);
            }
            SetViewData();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.Account, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, AccountCreateOrEditDto model)
        {
            List<ModelError> errors = new();
            try
            {
                if (!ModelState.IsValid)
                {
                    errors = ModelState
                            .Select(a => a.Value)
                            .SelectMany(a => a.Errors)
                            .ToList();

                    throw new Exception("");
                }

                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                Account dataDB = new();

                if (id == 0)
                {
                    dataDB = _mapper.Map<Account>(model);
                    _unitOfWork.Account.CreateAccount(dataDB);

                    dataDB.CreatedBy = auth.UserName;
                }
                else
                {
                    dataDB = await _unitOfWork.Account.FindAccountById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);

                    if (!string.IsNullOrEmpty(model.User.Password) && model.User.Password!=dataDB.User.Password)
                    {
                        dataDB.User.Password = _unitOfWork.Account.GeneratePassword(model.User.Password);
                    }

                    dataDB.LastModifiedBy = auth.UserName;
                }

                IFormFile imageFile = HttpContext.Request.Form.Files["ImageFile"];

                if (imageFile != null)
                {
                    dataDB.ImageUrl = await _unitOfWork.Account.UploadAccountImage(_environment.WebRootPath, imageFile);
                    dataDB.StorageUrl = _linkGenerator.GetUriByAction(HttpContext).GetBaseUri(HttpContext.Request.RouteValues["area"].ToString());
                }
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                errors.Add(new ModelError(ex, GetExceptionMsg(ex.Message)));
            }

            return BadRequest(errors);
        }

        [HttpPost]
        [Authorize(DashboardViewEnum.Account, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.Account.DeleteAccount(id);
                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                errors.Add(new ModelError(ex, GetExceptionMsg(ex.Message)));
            }

            return BadRequest(errors);
        }

        //helper methods
        public void SetViewData()
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            ViewData["AccountStates"] = _unitOfWork.Account.GetAccountStatesLookUp(new AccountStateParameters(), otherLang);
            ViewData["AccountTypes"] = _unitOfWork.Account.GetAccountTypesLookUp(new AccountTypeParameters(), otherLang);

        }

    }
}
