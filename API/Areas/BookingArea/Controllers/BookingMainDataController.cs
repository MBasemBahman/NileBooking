using API.Areas.BookingArea.Models;
using Entities.CoreServicesModels.BookingModels;

namespace API.Areas.BookingArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Booking")]
    [ApiExplorerSettings(GroupName = "Booking")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    public class BookingMainDataController : ExtendControllerBase
    {
        public BookingMainDataController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetBookingStates))]
        public async Task<IEnumerable<BookingStateDto>> GetBookingStates([FromQuery] BookingStateParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<BookingStateModel> data = await _unitOfWork.Booking.GetBookingStatesPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<BookingStateDto> dataDto = _mapper.Map<List<BookingStateDto>>(data);

            return dataDto;
        }

    }
}
