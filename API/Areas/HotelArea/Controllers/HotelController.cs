using API.Areas.HotelArea.Models;
using Entities.CoreServicesModels.HotelModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.HotelArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Hotel")]
    [ApiExplorerSettings(GroupName = "Hotel")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    public class HotelController : ExtendControllerBase
    {
        public HotelController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetHotels))]
        public async Task<IEnumerable<HotelDto>> GetHotels([FromQuery] HotelParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<HotelModel> data = await _unitOfWork.Hotel.GetHotelsPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<HotelDto> dataDto = _mapper.Map<List<HotelDto>>(data);

            return dataDto;
        }


        [HttpGet]
        [Route(nameof(GetHotel))]
        public async Task<HotelDto> GetHotel(
          [FromQuery, BindRequired] int id)
        {
            _ = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            //For My Reaction
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelModel hotel = _unitOfWork.Hotel.GetHotels(new HotelParameters
            {
                Id = id,
                IncludeExtraPrices= true,
                IncludeRooms= true,
                IncludeSelectedFeature= true,
                
            }, language).FirstOrDefault();

            HotelDto hotelDto = _mapper.Map<HotelDto>(hotel);

            hotelDto = await SetAttachments(hotelDto);

            return hotelDto;
        }

        // Helper Methods
        private async Task<HotelDto> SetAttachments(HotelDto hotel)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];


            if (hotel.AttachmentCount > 0 && hotel.Id > 0)
            {
                hotel.HotelAttachments = _mapper.Map<List<HotelAttachmentDto>>(
                    await _unitOfWork.Hotel.GetHotelAttachmentsPaged(new HotelAttachmentParameters
                    {
                        Fk_Hotel = hotel.Id,
                        PageNumber = 1,
                        PageSize = 5,
                    }, language));
            }

            return hotel;
        }

    }
}
