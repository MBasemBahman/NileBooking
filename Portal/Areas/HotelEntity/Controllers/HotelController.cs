using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.HotelEntity.Models;

namespace Portal.Areas.HotelEntity.Controllers
{
    [Area("HotelEntity")]
    [Authorize(DashboardViewEnum.Hotel, DashboardAccessLevelEnum.Viewer)]
    public class HotelController : ExtendControllerBase
    {
        public HotelController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }
        public IActionResult Index()
        {
            HotelFilter filter = new();

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] HotelFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<HotelModel> data = await _unitOfWork.Hotel.GetHotelsPaged(parameters, otherLang);

            List<HotelDto> resultDto = _mapper.Map<List<HotelDto>>(data);

            DataTable<HotelDto> dataTableManager = new();

            DataTableResult<HotelDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Hotel.GetHotelsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelDto data = _mapper.Map<HotelDto>(_unitOfWork.Hotel.GetHotelById(id, otherLang));

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
            }

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

                if (id == 0)
                {
                    dataDB = _mapper.Map<Hotel>(model);
                    _unitOfWork.Hotel.CreateHotel(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Hotel.FindHotelById(id, trackChanges: true);

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
    }
}
