using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.HotelModels;
using Entities.CoreServicesModels.LocationModels;

namespace Portal.Controllers
{
    public class ServicesController : ExtendControllerBase
    {
        public ServicesController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }

        [HttpGet]
		public JsonResult GetAreas(int Fk_Country)
		{
			LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            var result = _unitOfWork.Location.GetAreas(new AreaParameters
            {
                Fk_Country = Fk_Country
            }, language)
                .Select(a=> new
                {
                    a.Id,
                    a.Name
                }).ToList();

			return Json(result);
		}


		[HttpGet]
		public JsonResult getFeatures(int Fk_FeatureCategory)
		{
			LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

			var result = _unitOfWork.Hotel.GetHotelFeatures(new HotelFeatureParameters
			{
				Fk_HotelFeatureCategory = Fk_FeatureCategory
			}, language)
				.Select(a => new
				{
					a.Id,
					a.Name
				}).ToList();

			return Json(result);
		}
		
		[HttpGet]
		public JsonResult getAccountBySearch([FromQuery]string searchTerm)
		{
			LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

			var result = _unitOfWork.Account.GetAccounts(new AccountParameters
			{
				CustomSearch = searchTerm
			}, language)
				.Take(10)
				.ToDictionary(a => a.Id, a => $"{a.User.FullName} | {a.User.PhoneNumber}");

			return Json(result);
		}
		
		[HttpGet]
		public JsonResult getHotelBySearch([FromQuery]string searchTerm)
		{
			LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

			var result = _unitOfWork.Hotel.GetHotels(new HotelParameters
			{
				TxtSearch = searchTerm
			}, language)
				.Take(10)
				.ToDictionary(a => a.Id, a => a.Name);

			return Json(result);
		}

	}
}