using Portal.Areas.HotelEntity.Models;
using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;
using Entities.EnumData;
using Entities.RequestFeatures;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Portal.Areas.HotelEntity.Controllers
{
    [Area("HotelEntity")]
    [Authorize(DashboardViewEnum.HotelFeatureCategory, DashboardAccessLevelEnum.Viewer)]
    public class HotelFeatureCategoryController : ExtendControllerBase
    {
        public HotelFeatureCategoryController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }
        public IActionResult Index()
        {
            HotelFeatureCategoryFilter filter = new();

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] HotelFeatureCategoryFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelFeatureCategoryParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<HotelFeatureCategoryModel> data = await _unitOfWork.Hotel.GetHotelFeatureCategoriesPaged(parameters, otherLang);

            List<HotelFeatureCategoryDto> resultDto = _mapper.Map<List<HotelFeatureCategoryDto>>(data);

            DataTable<HotelFeatureCategoryDto> dataTableManager = new();

            DataTableResult<HotelFeatureCategoryDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Hotel.GetHotelFeatureCategoriesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelFeatureCategoryDto data = _mapper.Map<HotelFeatureCategoryDto>(_unitOfWork.Hotel.GetHotelFeatureCategoryById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.HotelFeatureCategory, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            HotelFeatureCategoryCreateOrEditModel model = new();

            if (id > 0)
            {
                HotelFeatureCategory dataDB = await _unitOfWork.Hotel.FindHotelFeatureCategoryById(id, trackChanges: false);
                model = _mapper.Map<HotelFeatureCategoryCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.HotelFeatureCategoryLangs ??= new List<HotelFeatureCategoryLangModel>();

                    if (model.HotelFeatureCategoryLangs.All(a => a.Language != language))
                    {
                        model.HotelFeatureCategoryLangs.Add(new HotelFeatureCategoryLangModel
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
        [Authorize(DashboardViewEnum.HotelFeatureCategory, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, HotelFeatureCategoryCreateOrEditModel model)
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
                HotelFeatureCategory dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<HotelFeatureCategory>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.Hotel.CreateHotelFeatureCategory(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Hotel.FindHotelFeatureCategoryById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);

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
        [Authorize(DashboardViewEnum.HotelFeatureCategory, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.Hotel.DeleteHotelFeatureCategory(id);
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
