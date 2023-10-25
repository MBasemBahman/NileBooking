using Entities.CoreServicesModels.BookingModels;
using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.BookingModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.BookingEntity.Models;

namespace Portal.Areas.BookingEntity.Controllers
{
    [Area("BookingEntity")]
    [Authorize(DashboardViewEnum.Booking, DashboardAccessLevelEnum.Viewer)]
    public class BookingController : ExtendControllerBase
    {
        public BookingController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }
        public IActionResult Index()
        {
            BookingFilter filter = new();

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] BookingFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            BookingParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<BookingModel> data = await _unitOfWork.Booking.GetBookingsPaged(parameters, otherLang);

            List<BookingDto> resultDto = _mapper.Map<List<BookingDto>>(data);

            DataTable<BookingDto> dataTableManager = new();

            DataTableResult<BookingDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Booking.GetBookingsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            BookingDto data = _mapper.Map<BookingDto>(_unitOfWork.Booking.GetBookingById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.Booking, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            BookingCreateOrEditModel model = new()
            {
                FromDate = DateTime.Today,
                ToDate = DateTime.Today,
            };

            if (id > 0)
            {
                Booking dataDB = await _unitOfWork.Booking.FindBookingById(id, trackChanges: false);
                model = _mapper.Map<BookingCreateOrEditModel>(dataDB);
            }

            setViewData();
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.Booking, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, BookingCreateOrEditModel model)
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
                
                Booking dataDB = new();

                if (id == 0)
                {
                    dataDB = _unitOfWork.Booking.CreateBooking(model);
                }
                else
                {
                    dataDB = await _unitOfWork.Booking.FindBookingById(id, trackChanges: true);

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
        [Authorize(DashboardViewEnum.Booking, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.Booking.DeleteBooking(id);
                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                errors.Add(new ModelError(ex, GetExceptionMsg(ex.Message)));
            }

            return BadRequest(errors);
        }

        private void setViewData()
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            ViewData["BookingState"] = _unitOfWork.Booking.GetBookingStatesLookUp(new BookingStateParameters(), language);
            ViewData["RoomType"] = _unitOfWork.HotelRoom.GetRoomTypesLookUp(new RoomTypeParameters(), language);
        }
    }
}
