using Entities.CoreServicesModels.LocationModels;
using Entities.DBModels.LocationModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.LocationEntity.Models;

namespace Portal.Areas.LocationEntity.Controllers
{
    [Area("LocationEntity")]
    [Authorize(DashboardViewEnum.Area, DashboardAccessLevelEnum.Viewer)]
    public class AreaController : ExtendControllerBase
    {
        public AreaController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }
        public IActionResult Index(int fk_Country, bool ProfileLayOut = false)
        {
            AreaFilter filter = new() { Fk_Country = fk_Country };

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            SetViewData();
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] AreaFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AreaParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<AreaModel> data = await _unitOfWork.Location.GetAreasPaged(parameters, otherLang);

            List<AreaDto> resultDto = _mapper.Map<List<AreaDto>>(data);

            DataTable<AreaDto> dataTableManager = new();

            DataTableResult<AreaDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Location.GetAreasCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AreaDto data = _mapper.Map<AreaDto>(_unitOfWork.Location.GetAreaById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.Area, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            AreaCreateOrEditModel model = new();

            if (id > 0)
            {
                Area dataDB = await _unitOfWork.Location.FindAreaById(id, trackChanges: false);
                model = _mapper.Map<AreaCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.AreaLangs ??= new List<AreaLangModel>();

                    if (model.AreaLangs.All(a => a.Language != language))
                    {
                        model.AreaLangs.Add(new AreaLangModel
                        {
                            Language = language
                        });
                    }
                }

                #endregion
            }
            SetViewData();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.Area, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, AreaCreateOrEditModel model)
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
                Area dataDB = new();

                if (id == 0)
                {
                    dataDB = _mapper.Map<Area>(model);
                    _unitOfWork.Location.CreateArea(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Location.FindAreaById(id, trackChanges: true);

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
        [Authorize(DashboardViewEnum.Area, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.Location.DeleteArea(id);
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

            ViewData["Countries"] = _unitOfWork.Location.GetCountriesLookUp(new CountryParameters(), otherLang);
        }
    }
}
