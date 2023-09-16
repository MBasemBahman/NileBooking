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


        [HttpGet]
        [Route(nameof(GetHotelFeatureCategories))]
        public async Task<IEnumerable<HotelFeatureCategoryDto>> GetHotelFeatureCategories([FromQuery] HotelFeatureCategoryParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<HotelFeatureCategoryModel> data = await _unitOfWork.Hotel.GetHotelFeatureCategoriesPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<HotelFeatureCategoryDto> dataDto = _mapper.Map<List<HotelFeatureCategoryDto>>(data);

            return dataDto;
        }

        [HttpGet]
        [Route(nameof(GetHotelFeatures))]
        public async Task<IEnumerable<HotelFeatureDto>> GetHotelFeatures([FromQuery] HotelFeatureParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<HotelFeatureModel> data = await _unitOfWork.Hotel.GetHotelFeaturesPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<HotelFeatureDto> dataDto = _mapper.Map<List<HotelFeatureDto>>(data);

            return dataDto;
        }




    }
}
