using API.Areas.HotelRoomArea.Models;
using Entities.CoreServicesModels.HotelRoomModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.HotelRoomArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("HotelRoom")]
    [ApiExplorerSettings(GroupName = "HotelRoom")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    public class HotelRoomController : ExtendControllerBase
    {
        public HotelRoomController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetHotelRooms))]
        public async Task<IEnumerable<HotelRoomDto>> GetHotelRooms([FromQuery] HotelRoomParameters parameters)
        {
            if (parameters.Fk_Hotel == 0)
            {
                throw new Exception("Bad Request!");
            }
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<HotelRoomModel> data = await _unitOfWork.HotelRoom.GetHotelRoomsPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<HotelRoomDto> dataDto = _mapper.Map<List<HotelRoomDto>>(data);

            return dataDto;
        }


        [HttpGet]
        [Route(nameof(GetHotelRoom))]
        public HotelRoomDto GetHotelRoom(
          [FromQuery, BindRequired] int id)
        {
            _ = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            //For My Reaction
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelRoomModel hotelRoom = _unitOfWork.HotelRoom.GetHotelRooms(new HotelRoomParameters
            {
                Id = id,
                IncludeRoomPrices = true,

            }, language).FirstOrDefault();

            HotelRoomDto hotelRoomDto = _mapper.Map<HotelRoomDto>(hotelRoom);

            return hotelRoomDto;
        }


    }
}
