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
    public class BookingRoomController : ExtendControllerBase
    {
        public BookingRoomController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetBookingRooms))]
        public async Task<IEnumerable<BookingRoomDto>> GetBookingRooms([FromQuery] BookingRoomParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            if (parameters.Fk_Booking == 0)
            {
                throw new Exception("Bad Request!");
            }
            PagedList<BookingRoomModel> data = await _unitOfWork.Booking.GetBookingRoomsPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<BookingRoomDto> dataDto = _mapper.Map<List<BookingRoomDto>>(data);

            return dataDto;
        }

        [HttpGet]
        [Route(nameof(GetBookingRoom))]
        public BookingRoomDto GetBookingRoom(
       [FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            BookingRoomModel bookingRoom = _unitOfWork.Booking.GetBookingRooms(new BookingRoomParameters
            {
                Id = id,
                IncludeBookingRoomExtra = true,
            }, language).FirstOrDefault();

            BookingRoomDto bookingRoomDto = _mapper.Map<BookingRoomDto>(bookingRoom);

            return bookingRoomDto;
        }

        [HttpPost]
        [Route(nameof(CreateBookingRoom))]
        public async Task<BookingRoomDto> CreateBookingRoom([FromBody] BookingRoomCreateDto model)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            _ = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            BookingRoom dataDb = _mapper.Map<BookingRoom>(model);

            _unitOfWork.Booking.CreateBookingRoom(dataDb);

            await _unitOfWork.Save();

            BookingRoomModel bookingRoom = _unitOfWork.Booking.GetBookingRooms(new BookingRoomParameters
            {
                Id = dataDb.Id,
                IncludeBookingRoomExtra = true,
            }, language).FirstOrDefault();

            BookingRoomDto bookingRoomDto = _mapper.Map<BookingRoomDto>(bookingRoom);

            return bookingRoomDto;
        }

        [HttpPut]
        [Route(nameof(EditBookingRoom))]

        public async Task<BookingRoomDto> EditBookingRoom([FromQuery, BindRequired] int id,
       [FromBody] BookingRoomEditDto model)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            _ = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            BookingRoom dataDb = await _unitOfWork.Booking.FindBookingRoomById(id, trackChanges: true);


            _ = _mapper.Map(model, dataDb);

            await _unitOfWork.Save();

            BookingRoomModel bookingRoom = _unitOfWork.Booking.GetBookingRooms(new BookingRoomParameters
            {
                Id = dataDb.Id,
                IncludeBookingRoomExtra = true,
            }, language).FirstOrDefault();

            BookingRoomDto bookingRoomDto = _mapper.Map<BookingRoomDto>(bookingRoom);

            return bookingRoomDto;
        }

        [HttpDelete]
        [Route(nameof(RemoveBookingRoom))]

        public async Task<bool> RemoveBookingRoom([FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            _ = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            _ = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            await _unitOfWork.Booking.DeleteBookingRoom(id);

            await _unitOfWork.Save();


            return true;
        }
    }
}
