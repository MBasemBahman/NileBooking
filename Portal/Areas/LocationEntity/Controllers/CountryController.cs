using Entities.CoreServicesModels.LocationModels;
using Entities.DBModels.LocationModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.LocationEntity.Models;

namespace Portal.Areas.LocationEntity.Controllers
{
    [Area("LocationEntity")]
    [Authorize(DashboardViewEnum.Country, DashboardAccessLevelEnum.Viewer)]
    public class CountryController : ExtendControllerBase
    {
        public CountryController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }
        public IActionResult Index(int id, bool ProfileLayOut = false)
        {
            CountryFilter filter = new();

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] CountryFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CountryParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<CountryModel> data = await _unitOfWork.Location.GetCountriesPaged(parameters, otherLang);

            List<CountryDto> resultDto = _mapper.Map<List<CountryDto>>(data);

            DataTable<CountryDto> dataTableManager = new();

            DataTableResult<CountryDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Location.GetCountriesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CountryDto data = _mapper.Map<CountryDto>(_unitOfWork.Location.GetCountryById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.Country, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            CountryCreateOrEditModel model = new();

            if (id > 0)
            {
                Country dataDB = await _unitOfWork.Location.FindCountryById(id, trackChanges: false);
                model = _mapper.Map<CountryCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.CountryLangs ??= new List<CountryLangModel>();

                    if (model.CountryLangs.All(a => a.Language != language))
                    {
                        model.CountryLangs.Add(new CountryLangModel
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
        [Authorize(DashboardViewEnum.Country, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, CountryCreateOrEditModel model)
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
                Country dataDB = new();

                if (id == 0)
                {
                    dataDB = _mapper.Map<Country>(model);
                    _unitOfWork.Location.CreateCountry(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Location.FindCountryById(id, trackChanges: true);

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
        [Authorize(DashboardViewEnum.Country, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.Location.DeleteCountry(id);
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
