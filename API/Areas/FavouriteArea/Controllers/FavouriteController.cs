using API.Areas.FavouriteArea.Models;
using Entities.CoreServicesModels.FavouriteModels;
using Entities.DBModels.FavouriteModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Services;

namespace API.Areas.FavouriteArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Favourite")]
    [ApiExplorerSettings(GroupName = "Favourite")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    public class FavouriteController : ExtendControllerBase
    {
        public FavouriteController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetAccountFavourites))]
        public async Task<IEnumerable<FavouriteAccountHotelDto>> GetAccountFavourites([FromQuery] FavouriteAccountHotelParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            parameters.Fk_Account = auth.Fk_Account;
            
            List<FavouriteAccountHotelModel> data = await _unitOfWork.Favourite.GetFavouriteAccountHotels(parameters, language).ToListAsync();
            
            PagedList<FavouriteAccountHotelModel> pagedData = PagedList<FavouriteAccountHotelModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);

            SetPagination(pagedData.MetaData, parameters);

            var dataDto = _mapper.Map<List<FavouriteAccountHotelDto>>(pagedData);
            
            return dataDto;
        }

        [HttpPost]
        [Route(nameof(AddOrRemoveFavouriteHotel))]
        public async Task<ActionResult> AddOrRemoveFavouriteHotel([FromBody, BindRequired] int fk_Hotel)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
            
            if (_unitOfWork.Favourite
                .GetFavouriteAccountHotels(new FavouriteAccountHotelParameters
                {
                    Fk_Account = auth.Fk_Account,
                    Fk_Hotel = fk_Hotel
                }, language)
                .Any())
            {
                await _unitOfWork.Favourite.DeleteFavouriteAccountHotel(auth.Fk_Account, fk_Hotel);
            }
            else
            {
                _unitOfWork.Favourite.CreateFavouriteAccountHotel(new FavouriteAccountHotel
                {
                    Fk_Account = auth.Fk_Account,
                    Fk_Hotel = fk_Hotel
                });
            }

            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
