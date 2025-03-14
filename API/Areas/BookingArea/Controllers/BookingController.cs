﻿using API.Areas.BookingArea.Models;
using Entities.CoreServicesModels.BookingModels;
using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.BookingModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Services;

namespace API.Areas.BookingArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Booking")]
    [ApiExplorerSettings(GroupName = "Booking")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    public class BookingController : ExtendControllerBase
    {
        private readonly CyberSourcePaymentService _paymentService;

        public BookingController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings,
        CyberSourcePaymentService paymentService) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        [Route(nameof(GetBookings))]
        public async Task<IEnumerable<BookingDto>> GetBookings([FromQuery] BookingParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            parameters.Fk_Account = auth.Fk_Account;

            PagedList<BookingModel> data = await _unitOfWork.Booking.GetBookingsPaged(parameters, language);

            SetPagination(data.MetaData, parameters);

            List<BookingDto> dataDto = _mapper.Map<List<BookingDto>>(data);

            return dataDto;
        }

        [HttpGet]
        [Route(nameof(GetBooking))]
        public BookingDto GetBooking(
       [FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            BookingModel booking = _unitOfWork.Booking.GetBookings(new BookingParameters
            {
                Id = id,
                IncludeReview = true,
                IncludeRooms = true,
            }, language).FirstOrDefault();

            BookingDto bookingDto = _mapper.Map<BookingDto>(booking);

            return bookingDto;
        }
        
        [HttpPost]
        [Route(nameof(CreateBooking))]
        public async Task<BookingDto> CreateBooking([FromBody] BookingCreateDto model)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            Booking dataDb = _unitOfWork.Booking.CreateBooking(model, auth);

            await _unitOfWork.Save();

            BookingModel booking = _unitOfWork.Booking.GetBookings(new BookingParameters
            {
                Id = dataDb.Id,
                IncludeReview = true,
                IncludeRooms = true,
            }, language).FirstOrDefault();

            BookingDto bookingDto = _mapper.Map<BookingDto>(booking);

            return bookingDto;
        }
        
        [HttpPut]
        [Route(nameof(CancelBooking))]
        public async Task<BookingDto> CancelBooking([FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            Booking dataDb = await _unitOfWork.Booking.FindBookingById(id, trackChanges: true);

            if (dataDb.Fk_Account != auth.Fk_Account)
            {
                throw new Exception("Not Allowed!");
            }

            dataDb.Fk_BookingState = (int)BookingStateEnum.Cancelled;
            await _unitOfWork.Save();


            BookingModel booking = _unitOfWork.Booking.GetBookings(new BookingParameters
            {
                Id = dataDb.Id,
                IncludeReview = true,
                IncludeRooms = true,
            }, language).FirstOrDefault();

            BookingDto bookingDto = _mapper.Map<BookingDto>(booking);

            return bookingDto;
        }


        [HttpGet]
        [Route(nameof(GetBookingPrice))]
        public double GetBookingPrice([FromBody] BookingCreateDto model)
        {
            BookingCreateModel booking = _mapper.Map<BookingCreateModel>(model);

            return _unitOfWork.Booking.CalculateBookingPrice(booking);
        }

        [HttpGet]
        [Route(nameof(RequestForPayment))]
        public ActionResult<string> RequestForPayment()
        {
            return _paymentService
                .GenerateCyberSourceForm("100.00", "USD", "", "", "", "", "", "");
        }
    }
}
