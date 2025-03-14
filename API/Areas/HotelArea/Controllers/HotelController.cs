﻿using API.Areas.HotelArea.Models;
using Entities.CoreServicesModels.HotelModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Services;

namespace API.Areas.HotelArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Hotel")]
    [ApiExplorerSettings(GroupName = "Hotel")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
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

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            parameters.Fk_FavouriteAccount = auth.Fk_Account;
            
            parameters.IsActive = true;
            List<HotelDto> dataDto = new();

            if (parameters.Latitude > 0 && parameters.Longitude > 0)
            {
                List<HotelModel> data = await _unitOfWork.Hotel.GetHotels(parameters, language).ToListAsync();

                data.ForEach(a => a.Distance = GeoCoordinateService.GetDistance(parameters.Latitude, parameters.Longitude, a.Latitude, a.Longitude));

                data = data.OrderBy(a => a.Distance).ToList();

                PagedList<HotelModel> pagedData = PagedList<HotelModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);

                SetPagination(pagedData.MetaData, parameters);

                dataDto = _mapper.Map<List<HotelDto>>(pagedData);
            }
            else
            {
                PagedList<HotelModel> data = await _unitOfWork.Hotel.GetHotelsPaged(parameters, language);
                SetPagination(data.MetaData, parameters);

                dataDto = _mapper.Map<List<HotelDto>>(data);

            }



            return dataDto;
        }


        [HttpGet]
        [Route(nameof(GetHotel))]
        public async Task<HotelDto> GetHotel(
          [FromQuery, BindRequired] int id)
        {

            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelModel hotel = _unitOfWork.Hotel.GetHotels(new HotelParameters
            {
                Id = id,
                IsActive = true,
                IncludeExtraPrices = true,
                IncludeRooms = true,
                IncludeSelectedFeature = true,
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
