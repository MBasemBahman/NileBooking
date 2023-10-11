using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;
using Entities.Extensions;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.HotelEntity.Models;

namespace Portal.Areas.HotelEntity.Controllers
{
    [Area("HotelEntity")]
    [Authorize(DashboardViewEnum.HotelFeature, DashboardAccessLevelEnum.Viewer)]
    public class HotelFeatureController : ExtendControllerBase
    {
        private readonly LinkGenerator _linkGenerator;

        public HotelFeatureController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer,
        LinkGenerator linkGenerator) : base(mapper, authManager, unitOfWork, environment, localizer)
        {
            _linkGenerator = linkGenerator;
        }

        public IActionResult Index(int id, int fk_HotelFeatureCategory)
        {

            HotelFeatureFilter filter = new()
            {
                Fk_HotelFeatureCategory = fk_HotelFeatureCategory
            };

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            SetViewData();

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] HotelFeatureFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelFeatureParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<HotelFeatureModel> data = await _unitOfWork.Hotel.GetHotelFeaturesPaged(parameters, otherLang);

            List<HotelFeatureDto> resultDto = _mapper.Map<List<HotelFeatureDto>>(data);

            DataTable<HotelFeatureDto> dataTableManager = new();

            DataTableResult<HotelFeatureDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Hotel.GetHotelFeaturesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelFeatureDto data = _mapper.Map<HotelFeatureDto>(_unitOfWork.Hotel.GetHotelFeatureById(id, otherLang));

            return View(data);
        }

        public async Task<ActionResult> CreateOrEditBulk(int id, List<int> hotelFeatures)
        {
            _unitOfWork.Hotel.UpdateHotelFeatures(id, hotelFeatures);

            await _unitOfWork.Save();

            return Ok(new HotelModel
            {
                Id = id
            });
        }

        [Authorize(DashboardViewEnum.HotelFeature, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            HotelFeatureCreateOrEditModel model = new();

            if (id > 0)
            {
                HotelFeature dataDB = await _unitOfWork.Hotel.FindHotelFeatureById(id, trackChanges: false);
                model = _mapper.Map<HotelFeatureCreateOrEditModel>(dataDB);
                model.ImageUrl = dataDB.StorageUrl + dataDB.ImageUrl;

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.HotelFeatureLangs ??= new List<HotelFeatureLangModel>();

                    if (model.HotelFeatureLangs.All(a => a.Language != language))
                    {
                        model.HotelFeatureLangs.Add(new HotelFeatureLangModel
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
        [Authorize(DashboardViewEnum.HotelFeature, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, HotelFeatureCreateOrEditModel model)
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
                HotelFeature dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<HotelFeature>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.Hotel.CreateHotelFeature(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Hotel.FindHotelFeatureById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);

                    dataDB.LastModifiedBy = auth.UserName;
                }

                IFormFile imageFile = HttpContext.Request.Form.Files["ImageFile"];

                if (imageFile != null)
                {
                    dataDB.ImageUrl = await _unitOfWork.Hotel.UploadHotelImage(_environment.WebRootPath, imageFile);
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
        [Authorize(DashboardViewEnum.HotelFeature, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.Hotel.DeleteHotelFeature(id);
                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                errors.Add(new ModelError(ex, GetExceptionMsg(ex.Message)));
            }

            return BadRequest(errors);
        }
        //helper method
        private void SetViewData()
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            ViewData["HotelFeatureCategory"] = _unitOfWork.Hotel.GetHotelFeatureCategorysLookUp(new HotelFeatureCategoryParameters(), otherLang);
        }

    }
}
