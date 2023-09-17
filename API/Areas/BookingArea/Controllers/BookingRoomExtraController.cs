using API.Areas.BookingArea.Models;
using Entities.CoreServicesModels.BookingModels;
using Entities.DBModels.BookingModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.BookingArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Booking")]
    [ApiExplorerSettings(GroupName = "Booking")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    public class BookingRoomExtraController : ExtendControllerBase
    {
        public BookingRoomExtraController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetBookingRoomExtras))]
        public async Task<IEnumerable<BookingRoomExtraDto>> GetBookingRoomExtras([FromQuery] BookingRoomExtraParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            if (parameters.Fk_BookingRoom == 0)
            {
                throw new Exception("Bad Request!");
            }
            PagedList<BookingRoomExtraModel> data = await _unitOfWork.Booking.GetBookingRoomExtrasPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<BookingRoomExtraDto> dataDto = _mapper.Map<List<BookingRoomExtraDto>>(data);

            return dataDto;
        }

        [HttpGet]
        [Route(nameof(GetBookingRoomExtra))]
        public BookingRoomExtraDto GetBookingRoomExtra(
       [FromQuery, BindRequired] int id)
        {

            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            BookingRoomExtraModel bookingRoomExtra = _unitOfWork.Booking.GetBookingRoomExtraById(id,language);

            BookingRoomExtraDto bookingRoomExtraDto = _mapper.Map<BookingRoomExtraDto>(bookingRoomExtra);

            return bookingRoomExtraDto;
        }
    }
}
