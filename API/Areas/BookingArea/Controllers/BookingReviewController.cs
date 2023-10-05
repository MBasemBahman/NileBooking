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
    public class BookingReviewController : ExtendControllerBase
    {
        public BookingReviewController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetBookingReviews))]
        public async Task<IEnumerable<BookingReviewDto>> GetBookingReviews([FromQuery] BookingReviewParameters parameters)
        {
            PagedList<BookingReviewModel> data = await _unitOfWork.Booking.GetBookingReviewsPaged(parameters);

            SetPagination(data.MetaData, parameters);

            List<BookingReviewDto> dataDto = _mapper.Map<List<BookingReviewDto>>(data);

            return dataDto;
        }

        [HttpGet]
        [Route(nameof(GetBookingReview))]
        public BookingReviewDto GetBookingReview(
       [FromQuery, BindRequired] int Fk_Booking)
        {

            if (Fk_Booking == 0)
            {
                throw new Exception("Bad Request!");
            }

            BookingReviewModel bookingReview = _unitOfWork.Booking.GetBookingReviews(new BookingReviewParameters
            {
                Fk_Booking = Fk_Booking,
            }).FirstOrDefault();

            BookingReviewDto bookingReviewDto = _mapper.Map<BookingReviewDto>(bookingReview);

            return bookingReviewDto;
        }


        [HttpPut]
        [Route(nameof(EditBookingReview))]

        public async Task<BookingReviewDto> EditBookingReview([FromQuery, BindRequired] int Fk_Booking,
         [FromBody] BookingReviewEditDto model)
        {
            if (Fk_Booking == 0)
            {
                throw new Exception("Bad Request!");
            }

            _ = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            _ = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            BookingReview dataDb = await _unitOfWork.Booking.FindBookingReviewByBookingId(Fk_Booking, trackChanges: true);

            _ = _mapper.Map(model, dataDb);

            await _unitOfWork.Save();

            BookingReviewModel bookingReview = _unitOfWork.Booking.GetBookingReviews(new BookingReviewParameters
            {
                Fk_Booking = Fk_Booking,
            }).FirstOrDefault();

            BookingReviewDto bookingReviewDto = _mapper.Map<BookingReviewDto>(bookingReview);

            return bookingReviewDto;
        }

    }
}
