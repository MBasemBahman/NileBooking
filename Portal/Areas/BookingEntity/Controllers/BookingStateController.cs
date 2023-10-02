using Entities.CoreServicesModels.BookingModels;
using Entities.DBModels.BookingModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.BookingEntity.Models;

namespace Portal.Areas.BookingEntity.Controllers
{
    [Area("BookingEntity")]
    [Authorize(DashboardViewEnum.BookingState, DashboardAccessLevelEnum.Viewer)]
    public class BookingStateController : ExtendControllerBase
    {
        public BookingStateController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }
        public IActionResult Index()
        {
            BookingStateFilter filter = new();

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] BookingStateFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            BookingStateParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<BookingStateModel> data = await _unitOfWork.Booking.GetBookingStatesPaged(parameters, otherLang);

            List<BookingStateDto> resultDto = _mapper.Map<List<BookingStateDto>>(data);

            DataTable<BookingStateDto> dataTableManager = new();

            DataTableResult<BookingStateDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Booking.GetBookingStatesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            BookingStateDto data = _mapper.Map<BookingStateDto>(_unitOfWork.Booking.GetBookingStateById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.BookingState, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            BookingStateCreateOrEditModel model = new();

            if (id > 0)
            {
                BookingState dataDB = await _unitOfWork.Booking.FindBookingStateById(id, trackChanges: false);
                model = _mapper.Map<BookingStateCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.BookingStateLangs ??= new List<BookingStateLangModel>();

                    if (model.BookingStateLangs.All(a => a.Language != language))
                    {
                        model.BookingStateLangs.Add(new BookingStateLangModel
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
        [Authorize(DashboardViewEnum.BookingState, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, BookingStateCreateOrEditModel model)
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
                BookingState dataDB = new();

                if (id == 0)
                {
                    dataDB = _mapper.Map<BookingState>(model);
                    _unitOfWork.Booking.CreateBookingState(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Booking.FindBookingStateById(id, trackChanges: true);

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
        [Authorize(DashboardViewEnum.BookingState, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.Booking.DeleteBookingState(id);
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
