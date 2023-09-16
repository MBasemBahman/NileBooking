using API.Areas.LocationArea.Models;
using Entities.CoreServicesModels.LocationModels;

namespace API.Areas.LocationArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Location")]
    [ApiExplorerSettings(GroupName = "Location")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    public class LocationController : ExtendControllerBase
    {
        public LocationController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetCountries))]
        public async Task<IEnumerable<CountryDto>> GetCountries([FromQuery] CountryParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<CountryModel> data = await _unitOfWork.Location.GetCountriesPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<CountryDto> dataDto = _mapper.Map<List<CountryDto>>(data);

            return dataDto;
        }


        [HttpGet]
        [Route(nameof(GetAreas))]
        public async Task<IEnumerable<AreaDto>> GetAreas([FromQuery] AreaParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<AreaModel> data = await _unitOfWork.Location.GetAreasPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<AreaDto> dataDto = _mapper.Map<List<AreaDto>>(data);

            return dataDto;
        }

    }
}
