using Entities.CoreServicesModels.HotelModels;
using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.HotelModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.HotelEntity.Models;

namespace Portal.Areas.HotelEntity.Controllers
{
    [Area("HotelEntity")]
    [Authorize(DashboardViewEnum.HotelExtra, DashboardAccessLevelEnum.Viewer)]
    public class HotelExtraController : ExtendControllerBase
    {
        public HotelExtraController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }
        public IActionResult Index(int Fk_Hotel)
        {
            HotelExtraFilter filter = new()
            {
                Fk_Hotel = Fk_Hotel,
            };

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] HotelExtraFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelExtraPriceParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<HotelExtraPriceModel> data = await _unitOfWork.Hotel.GetHotelExtraPricesPaged(parameters, otherLang);

            List<HotelExtraDto> resultDto = _mapper.Map<List<HotelExtraDto>>(data);

            DataTable<HotelExtraDto> dataTableManager = new();

            DataTableResult<HotelExtraDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Hotel.GetHotelExtraPricesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelExtraDto data = _mapper.Map<HotelExtraDto>(_unitOfWork.Hotel.GetHotelExtraPriceById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.HotelExtra, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0, int fk_Hotel = 0)
        {
            HotelExtraCreateOrEditModel model = new()
            {
                Fk_Hotel = fk_Hotel
            };
            
            if (id > 0)
            {
                HotelExtraPrice dataDB = await _unitOfWork.Hotel.FindHotelExtraPriceById(id, trackChanges: false);
                model = _mapper.Map<HotelExtraCreateOrEditModel>(dataDB);
                
                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.HotelExtraPriceLangs ??= new List<HotelExtraLangModel>();

                    if (model.HotelExtraPriceLangs.All(a => a.Language != language))
                    {
                        model.HotelExtraPriceLangs.Add(new HotelExtraLangModel
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
        [Authorize(DashboardViewEnum.HotelExtra, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, HotelExtraCreateOrEditModel model)
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
                HotelExtraPrice dataDB = new();

                if (id == 0)
                {
                    dataDB = _mapper.Map<HotelExtraPrice>(model);
                    _unitOfWork.Hotel.CreateHotelExtraPrice(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Hotel.FindHotelExtraPriceById(id, trackChanges: true);

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
        [Authorize(DashboardViewEnum.HotelExtra, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.Hotel.DeleteHotelExtraPrice(id);
                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                errors.Add(new ModelError(ex, GetExceptionMsg(ex.Message)));
            }

            return BadRequest(errors);
        }

        public void SetViewData()
        {
            //
        }
    }
}
