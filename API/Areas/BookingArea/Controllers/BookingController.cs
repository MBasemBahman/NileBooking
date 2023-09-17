using API.Areas.BookingArea.Models;
using Entities.CoreServicesModels.BookingModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.BookingArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Booking")]
    [ApiExplorerSettings(GroupName = "Booking")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    public class BookingController : ExtendControllerBase
    {
        public BookingController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetBookings))]
        public async Task<IEnumerable<BookingDto>> GetBookings([FromQuery] BookingParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            parameters.Fk_Account = auth.Fk_Account;

            PagedList<BookingModel> data = await _unitOfWork.Booking.GetBookingsPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<BookingDto> dataDto = _mapper.Map<List<BookingDto>>(data);

            return dataDto;
        }

        [HttpGet]
        [Route(nameof(GetBooking))]
        public BookingDto GetBooking(
       [FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            BookingModel booking = _unitOfWork.Booking.GetBookings(new BookingParameters
            {
                Id = id,
                IncludeReview = true,
                IncludeRooms = true,
            }, language).FirstOrDefault();

            BookingDto bookingDto = _mapper.Map<BookingDto>(booking);

            return bookingDto;
        }
    }
}
