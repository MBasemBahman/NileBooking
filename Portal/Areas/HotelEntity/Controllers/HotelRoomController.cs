using Entities.CoreServicesModels.HotelModels;
using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.HotelModels;
using Entities.DBModels.HotelRoomModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.HotelEntity.Models;

namespace Portal.Areas.HotelEntity.Controllers
{
    [Area("HotelEntity")]
    [Authorize(DashboardViewEnum.HotelRoom, DashboardAccessLevelEnum.Viewer)]
    public class HotelRoomController : ExtendControllerBase
    {
        public HotelRoomController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }
        public IActionResult Index(int Fk_Hotel)
        {
            HotelRoomFilter filter = new()
            {
                Fk_Hotel = Fk_Hotel,
            };

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] HotelRoomFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelRoomParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<HotelRoomModel> data = await _unitOfWork.HotelRoom.GetHotelRoomsPaged(parameters, otherLang);

            List<HotelRoomDto> resultDto = _mapper.Map<List<HotelRoomDto>>(data);

            DataTable<HotelRoomDto> dataTableManager = new();

            DataTableResult<HotelRoomDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.HotelRoom.GetHotelRoomsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelRoomDto data = _mapper.Map<HotelRoomDto>(_unitOfWork.HotelRoom.GetHotelRoomById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.HotelRoom, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0, int fk_Hotel = 0)
        {
            HotelRoomCreateOrEditModel model = new()
            {
                Fk_Hotel = fk_Hotel
            };
            
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            if (id > 0)
            {
                HotelRoom dataDB = await _unitOfWork.HotelRoom.FindHotelRoomById(id, trackChanges: false);
                model = _mapper.Map<HotelRoomCreateOrEditModel>(dataDB);

                model.HotelRoomPrices = _unitOfWork.HotelRoom.GetHotelRoomPrices(new HotelRoomPriceParameters
                {
                    Fk_HotelRoom = id,
                }, language).Select(b => new HotelRoomPriceCreateOrEditModel
                {
                    Id = b.Id,
                    AdultPrice = b.AdultPrice,
                    ChildPrice = b.ChildPrice,
                    FromDate = b.FromDate,
                    ToDate = b.ToDate
                }).ToList();
            }

            SetViewData();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.HotelRoom, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, HotelRoomCreateOrEditModel model)
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
                HotelRoom dataDB = new();

                if (id == 0)
                {
                    dataDB = _mapper.Map<HotelRoom>(model);
                    _unitOfWork.HotelRoom.CreateHotelRoom(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.HotelRoom.FindHotelRoomById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);
                }

                await _unitOfWork.Save();
                
                await _unitOfWork.HotelRoom.UpdateHotelRoomPrices(dataDB.Id, model.HotelRoomPrices);
                
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
        [Authorize(DashboardViewEnum.HotelRoom, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.HotelRoom.DeleteHotelRoom(id);
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
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            ViewData["RoomTypes"] = _unitOfWork.HotelRoom.GetRoomTypesLookUp(new RoomTypeParameters(), language);
            ViewData["RoomFoodTypes"] = _unitOfWork.HotelRoom.GetRoomFoodTypesLookUp(new RoomFoodTypeParameters(), language);
        }
    }
}
