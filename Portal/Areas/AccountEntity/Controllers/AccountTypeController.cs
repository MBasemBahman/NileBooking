using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.AccountEntity.Models;

namespace Portal.Areas.AccountEntity.Controllers
{
    [Area("AccountEntity")]
    [Authorize(DashboardViewEnum.AccountType, DashboardAccessLevelEnum.Viewer)]
    public class AccountTypeController : ExtendControllerBase
    {
        public AccountTypeController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }
        public IActionResult Index(int id, bool ProfileLayOut = false)
        {
            AccountTypeFilter filter = new()
            {
                Id = id
            };

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] AccountTypeFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AccountTypeParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<AccountTypeModel> data = await _unitOfWork.Account.GetAccountTypesPaged(parameters, otherLang);

            List<AccountTypeDto> resultDto = _mapper.Map<List<AccountTypeDto>>(data);

            DataTable<AccountTypeDto> dataTableManager = new();

            DataTableResult<AccountTypeDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Account.GetAccountTypesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AccountTypeDto data = _mapper.Map<AccountTypeDto>(_unitOfWork.Account.GetAccountTypeById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.AccountType, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            AccountTypeCreateOrEditModel model = new();

            if (id > 0)
            {
                AccountType dataDB = await _unitOfWork.Account.FindAccountTypeById(id, trackChanges: false);
                model = _mapper.Map<AccountTypeCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.AccountTypeLangs ??= new List<AccountTypeLangModel>();

                    if (model.AccountTypeLangs.All(a => a.Language != language))
                    {
                        model.AccountTypeLangs.Add(new AccountTypeLangModel
                        {
                            Language = language
                        });
                    }
                }

                #endregion
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.AccountType, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, AccountTypeCreateOrEditModel model)
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
                AccountType dataDB = new();

                if (id == 0)
                {
                    dataDB = _mapper.Map<AccountType>(model);
                    _unitOfWork.Account.CreateAccountType(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Account.FindAccountTypeById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);
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
        [Authorize(DashboardViewEnum.AccountType, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.Account.DeleteAccountType(id);
                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                errors.Add(new ModelError(ex, GetExceptionMsg(ex.Message)));
            }

            return BadRequest(errors);
        }
    }
}
