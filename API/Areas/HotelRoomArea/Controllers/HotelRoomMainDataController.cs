using API.Areas.HotelRoomArea.Models;
using Entities.CoreServicesModels.HotelRoomModels;

namespace API.Areas.HotelRoomArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("HotelRoom")]
    [ApiExplorerSettings(GroupName = "HotelRoom")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    public class HotelRoomMainDataController : ExtendControllerBase
    {
        public HotelRoomMainDataController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetRoomTypes))]
        public async Task<IEnumerable<RoomTypeDto>> GetRoomTypes([FromQuery] RoomTypeParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<RoomTypeModel> data = await _unitOfWork.HotelRoom.GetRoomTypesPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<RoomTypeDto> dataDto = _mapper.Map<List<RoomTypeDto>>(data);

            return dataDto;
        }


        [HttpGet]
        [Route(nameof(GetRoomFoodTypes))]
        public async Task<IEnumerable<RoomFoodTypeDto>> GetRoomFoodTypes([FromQuery] RoomFoodTypeParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<RoomFoodTypeModel> data = await _unitOfWork.HotelRoom.GetRoomFoodTypesPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<RoomFoodTypeDto> dataDto = _mapper.Map<List<RoomFoodTypeDto>>(data);

            return dataDto;
        }

    }
}
