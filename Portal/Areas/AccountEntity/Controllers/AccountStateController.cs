﻿using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.AccountEntity.Models;

namespace Portal.Areas.AccountEntity.Controllers
{
    [Area("AccountEntity")]
    [Authorize(DashboardViewEnum.AccountState, DashboardAccessLevelEnum.Viewer)]
    public class AccountStateController : ExtendControllerBase
    {
        public AccountStateController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }
        public IActionResult Index()
        {
            AccountStateFilter filter = new();

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] AccountStateFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AccountStateParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<AccountStateModel> data = await _unitOfWork.Account.GetAccountStatesPaged(parameters, otherLang);

            List<AccountStateDto> resultDto = _mapper.Map<List<AccountStateDto>>(data);

            DataTable<AccountStateDto> dataTableManager = new();

            DataTableResult<AccountStateDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Account.GetAccountStatesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AccountStateDto data = _mapper.Map<AccountStateDto>(_unitOfWork.Account.GetAccountStateById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.AccountState, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            AccountStateCreateOrEditModel model = new();

            if (id > 0)
            {
                AccountState dataDB = await _unitOfWork.Account.FindAccountStateById(id, trackChanges: false);
                model = _mapper.Map<AccountStateCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.AccountStateLangs ??= new List<AccountStateLangModel>();

                    if (model.AccountStateLangs.All(a => a.Language != language))
                    {
                        model.AccountStateLangs.Add(new AccountStateLangModel
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
        [Authorize(DashboardViewEnum.AccountState, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, AccountStateCreateOrEditModel model)
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
                AccountState dataDB = new();

                if (id == 0)
                {
                    dataDB = _mapper.Map<AccountState>(model);
                    _unitOfWork.Account.CreateAccountState(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Account.FindAccountStateById(id, trackChanges: true);

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
        [Authorize(DashboardViewEnum.AccountState, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.Account.DeleteAccountState(id);
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
