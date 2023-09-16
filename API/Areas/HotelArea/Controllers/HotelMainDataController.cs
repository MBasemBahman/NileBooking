using API.Areas.HotelArea.Models;
using Entities.CoreServicesModels.HotelModels;

namespace API.Areas.HotelArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Hotel")]
    [ApiExplorerSettings(GroupName = "Hotel")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    public class HotelMainDataController : ExtendControllerBase
    {
        public HotelMainDataController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetHotelTypes))]
        public async Task<IEnumerable<HotelTypeDto>> GetHotelTypes([FromQuery] HotelTypeParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<HotelTypeModel> data = await _unitOfWork.Hotel.GetHotelTypesPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<HotelTypeDto> dataDto = _mapper.Map<List<HotelTypeDto>>(data);

            return dataDto;
        }




    }
}
