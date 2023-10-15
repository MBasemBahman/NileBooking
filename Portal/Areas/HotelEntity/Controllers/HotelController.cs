using Entities.CoreServicesModels.HotelModels;
using Entities.CoreServicesModels.LocationModels;
using Entities.DBModels.HotelModels;
using Entities.Extensions;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.HotelEntity.Models;

namespace Portal.Areas.HotelEntity.Controllers
{
    [Area("HotelEntity")]
    [Authorize(DashboardViewEnum.Hotel, DashboardAccessLevelEnum.Viewer)]
    public class HotelController : ExtendControllerBase
    {
        private readonly LinkGenerator _linkGenerator;
        public HotelController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer,
        LinkGenerator linkGenerator) : base(mapper, authManager, unitOfWork, environment, localizer)
        {
            _linkGenerator = linkGenerator;
        }
        public IActionResult Index()
        {
            HotelFilter filter = new();

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            return View(filter);
        }
        
        [HttpPost]
        public async Task<ActionResult> LoadHotels(HotelParameters parameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            parameters.SearchTerm = "";

            PagedList<HotelModel> data = await _unitOfWork.Hotel.GetHotelsPaged(parameters, otherLang);

            List<HotelDto> resultDto = _mapper.Map<List<HotelDto>>(data);

            Pagination<HotelDto> result = new(parameters.PageNumber,
                parameters.PageSize, resultDto, _unitOfWork.Hotel.GetHotelsCount(parameters));

            return Json(result);
        }

        public IActionResult Profile(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelDto data = _mapper.Map<HotelDto>(_unitOfWork.Hotel.GetHotelById(id, otherLang));

            return View(data);
        }
        
        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelDto data = _mapper.Map<HotelDto>(_unitOfWork.Hotel.GetHotels(new HotelParameters
            {
                Id =id,
                IncludeSelectedFeature = true
            }, otherLang).FirstOrDefault());

            return View(data);
        }

        [Authorize(DashboardViewEnum.Hotel, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            HotelCreateOrEditModel model = new();

            if (id > 0)
            {
                Hotel dataDB = await _unitOfWork.Hotel.FindHotelById(id, trackChanges: false);
                model = _mapper.Map<HotelCreateOrEditModel>(dataDB);
                model.ImageUrl = dataDB.StorageUrl + dataDB.ImageUrl;

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.HotelLangs ??= new List<HotelLangModel>();

                    if (model.HotelLangs.All(a => a.Language != language))
                    {
                        model.HotelLangs.Add(new HotelLangModel
                        {
                            Language = language
                        });
                    }
                }

                #endregion
                
                LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
                
                model.Fk_HotelSelectedFeatures = _unitOfWork.Hotel
                    .GetHotelSelectedFeatures(new HotelSelectedFeaturesParameters
                    {
                        Fk_Hotel = id
                    }, otherLang).Select(a => a.Fk_HotelFeature).ToList();

                if(model.Fk_Area != null)
                {
                    model.Fk_Country = _unitOfWork.Location.GetAreaById((int)model.Fk_Area, language: null).Fk_Country;
                }
            }

            SetViewData();
                
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.Hotel, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, HotelCreateOrEditModel model)
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
                Hotel dataDB = new();

                model.Fk_Area = model.Fk_Area > 0 ? model.Fk_Area : null;

                if (id == 0)
                {
                    dataDB = _mapper.Map<Hotel>(model);
                    dataDB.CreatedBy = auth.UserName;
                    dataDB.LastModifiedBy = auth.UserName;
                    
                    _unitOfWork.Hotel.CreateHotel(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Hotel.FindHotelById(id, trackChanges: true);

                    dataDB.LastModifiedBy = auth.UserName;
                    
                    _ = _mapper.Map(model, dataDB);
                }

                IFormFile imageFile = HttpContext.Request.Form.Files["ImageFile"];

                if (imageFile != null)
                {
                    dataDB.ImageUrl = await _unitOfWork.Hotel.UploadHotelImage(_environment.WebRootPath, imageFile);
                    dataDB.StorageUrl = _linkGenerator.GetUriByAction(HttpContext).GetBaseUri(HttpContext.Request.RouteValues["area"].ToString());
                }
                
                await _unitOfWork.Save();

                _unitOfWork.Hotel.UpdateHotelFeatures(dataDB.Id, model.Fk_HotelSelectedFeatures);
                
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
        [Authorize(DashboardViewEnum.Hotel, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.Hotel.DeleteHotel(id);
                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                errors.Add(new ModelError(ex, GetExceptionMsg(ex.Message)));
            }

            return BadRequest(errors);
        }

        private void SetViewData(int fk_Country = 0)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            ViewData["Country"] = _unitOfWork.Location.GetCountriesLookUp(new CountryParameters(), language);
            ViewData["Area"] = _unitOfWork.Location.GetAreasLookUp(new AreaParameters() { Fk_Country = fk_Country}, language);
            ViewData["HotelType"] = _unitOfWork.Hotel.GetHotelTypesLookUp(new HotelTypeParameters(), language);
            ViewData["HotelFeatures"] = _unitOfWork.Hotel.GetHotelFeaturesLookUp(new HotelFeatureParameters(), language);
            ViewData["FeatureCategory"] = _unitOfWork.Hotel.GetHotelFeatureCategorysLookUp(new HotelFeatureCategoryParameters (), language);
        }
    }
}
