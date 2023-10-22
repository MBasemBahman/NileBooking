using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.DashboardAdministrationModels;
using Entities.DBModels.DashboardAdministrationModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Portal.Areas.DashboardAdministrationEntity.Models;

namespace Portal.Areas.DashboardAdministrationEntity.Controllers
{
    [Area("DashboardAdministrationEntity")]
    [Authorize(DashboardViewEnum.DashboardAdministrator, DashboardAccessLevelEnum.Viewer)]
    public class DashboardAdministratorController : ExtendControllerBase
    {
        private readonly LinkGenerator _linkGenerator;

        public DashboardAdministratorController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LinkGenerator linkGenerator,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {
            _linkGenerator = linkGenerator;
        }

        public IActionResult Index()
        {
           
            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

           
            SetViewData();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] DashboardAdministratorFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            DashboardAdministratorParameters parameters = new()
            {
                SearchColumns = "Id"
            };

            _ = _mapper.Map(dtParameters, parameters);

            parameters.GetDevelopers = true;

            PagedList<DashboardAdministratorModel> data = await _unitOfWork.DashboardAdministration.GetAdministratorsPaged(parameters, otherLang);

            List<DashboardAdministratorDto> resultDto = _mapper.Map<List<DashboardAdministratorDto>>(data);

            DataTable<DashboardAdministratorDto> dataTableManager = new();

            DataTableResult<DashboardAdministratorDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.DashboardAdministration.GetAdministratorsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        // public IActionResult Details(int id)
        // {
        //     LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
        //
        //     DashboardAdministratorDto data = _mapper.Map<DashboardAdministratorDto>(_unitOfWork.DashboardAdministration.GetAdministratorbyId(id, otherLang));
        //
        //     return View(data);
        // }

        [Authorize(DashboardViewEnum.DashboardAdministrator, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            DashboardAdministratorCreateOrEditDto model = new();
            if (id > 0)
            {
                DashboardAdministrator dataDB = await _unitOfWork.DashboardAdministration.FindAdministratorById(id, trackChanges: false);
                model = _mapper.Map<DashboardAdministratorCreateOrEditDto>(dataDB);
            }
            SetViewData();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.DashboardAdministrator, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, DashboardAdministratorCreateOrEditDto model)
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
                DashboardAdministrator dataDB = new();

                if (id == 0)
                {
                    dataDB = _mapper.Map<DashboardAdministrator>(model);
                    _unitOfWork.DashboardAdministration.CreateAdministrator(dataDB);

                    dataDB.CreatedBy = auth.UserName;
                }
                else
                {
                    dataDB = await _unitOfWork.DashboardAdministration.FindAdministratorById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);

                    if (!string.IsNullOrEmpty(model.User.Password) && model.User.Password != dataDB.User.Password)
                    {
                        dataDB.User.Password = _unitOfWork.Account.GeneratePassword(model.User.Password);
                    }

                    dataDB.LastModifiedBy = auth.UserName;
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
        [Authorize(DashboardViewEnum.DashboardAdministrator, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.DashboardAdministration.DeleteAdministrator(id);
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
            ViewData["Roles"] = _unitOfWork.DashboardAdministration.GetRolesLookUp(new DashboardAdministrationRoleRequestParameters(), otherLang);
        }

    }
}
