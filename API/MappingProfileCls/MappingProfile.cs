#region Dto Models
using API.Areas.UserArea.Models;
using API.Areas.AccountArea.Models;
using API.Areas.LocationArea.Models;
using API.Areas.HotelArea.Models;
using API.Areas.HotelRoomArea.Models;
using API.Areas.BookingArea.Models;
#endregion

#region CoreService Models
using Entities.CoreServicesModels.UserModels;
using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.LocationModels;
using Entities.CoreServicesModels.HotelModels;
using Entities.CoreServicesModels.HotelRoomModels;
using Entities.CoreServicesModels.BookingModels;


#endregion

#region DB Models
using Entities.DBModels.UserModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.BookingModels;
#endregion


using System.Globalization;

namespace API.MappingProfileCls
{
    public class MappingProfile : Profile
    {
        private readonly AppSettings _appSettings;
        private TenantEnvironments _tenantEnvironment;

        public MappingProfile(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            SetTenantEnvironment();

            MapperConfiguration configuration = new(cfg =>
            {
                cfg.AllowNullCollections = false;
            });

            CreateMap<DateTime, string>().ConvertUsing(new DateTimeTypeConverter());
            CreateMap<DateTime?, string>().ConvertUsing(new DateTimeNullableTypeConverter());
            CreateMap<string, string>().ConvertUsing(new StringTypeConverter());
            CreateMap<TimeSpan, string>().ConvertUsing(new TimeSpanTypeConverter());
            CreateMap<TimeSpan?, string>().ConvertUsing(new TimeSpanNullableTypeConverter());
            CreateMap<string, List<string>>().ConvertUsing(new ListOfStringTypeConverter());

            #region Authentication Models

            _ = CreateMap<UserForRegistrationDto, User>();

            _ = CreateMap<UserAuthenticatedDto, UserDto>();

            #endregion

            #region User Models

            _ = CreateMap<UserForEditDto, User>();

            _ = CreateMap<UserForEditCultureDto, User>();

            _ = CreateMap<DeviceCreateModel, Device>();

            _ = CreateMap<User, UserDto>();



            #endregion

            #region Account Models

            _ = CreateMap<AccountModel, AccountDto>();

            _ = CreateMap<AccountStateModel, AccountStateDto>();

            _ = CreateMap<AccountTypeModel, AccountTypeDto>();

            _ = CreateMap<AccountCreateOrEditDto, Account>();
            #endregion

            #region Location Models
            _ = CreateMap<AreaModel, AreaDto>();

            _ = CreateMap<CountryModel, CountryDto>();
            #endregion

            #region Hotel Models
            _ = CreateMap<HotelAttachmentModel, HotelAttachmentDto>();

            _ = CreateMap<HotelModel, HotelDto>();

            _ = CreateMap<HotelExtraPriceModel, HotelExtraPriceDto>();

            _ = CreateMap<HotelFeatureModel, HotelFeatureDto>();

            _ = CreateMap<HotelFeatureCategoryModel, HotelFeatureCategoryDto>();

            _ = CreateMap<HotelTypeModel, HotelTypeDto>();

            _ = CreateMap<HotelSelectedFeaturesWithCategoryModel, HotelSelectedFeaturesWithCategoryDto>();
            #endregion

            #region Hotel Room Models

            _ = CreateMap<HotelRoomModel, HotelRoomDto>();

            _ = CreateMap<HotelRoomPriceModel, HotelRoomPriceDto>();

            _ = CreateMap<RoomFoodTypeModel, RoomFoodTypeDto>();

            _ = CreateMap<RoomTypeModel, RoomTypeDto>();
            #endregion

            #region Booking Models
            _ = CreateMap<BookingModel, BookingDto>();

            _ = CreateMap<BookingCreateDto, Booking>()
                .ForMember(dest => dest.BookingRooms, opt => opt.Ignore());

            _ = CreateMap<BookingEditDto, Booking>();

            _ = CreateMap<BookingReviewModel, BookingReviewDto>();

            _ = CreateMap<BookingRoomModel, BookingRoomDto>();

            _ = CreateMap<BookingRoomCreateDto, BookingRoom>();

            _ = CreateMap<BookingRoomEditDto, BookingRoom>();

            _ = CreateMap<BookingRoomExtraModel, BookingRoomExtraDto>();

            _ = CreateMap<BookingRoomExtraCreateDto, BookingRoomExtra>();

            _ = CreateMap<BookingStateModel, BookingStateDto>();

            _ = CreateMap<BookingReviewModel, BookingReviewDto>();

            _ = CreateMap<BookingReviewEditDto, BookingReview>();
            #endregion
        }

        private void SetTenantEnvironment()
        {
            foreach (TenantEnvironments item in (TenantEnvironments[])Enum.GetValues(typeof(TenantEnvironments)))
            {
                if (_appSettings.TenantEnvironment.ToUpper() == item.ToString())
                {
                    _tenantEnvironment = item;
                    break;
                }
            }
        }

        public class DateTimeNullableTypeConverter : ITypeConverter<DateTime?, string>
        {
            public string Convert(DateTime? source, string destination, ResolutionContext context)
            {
                return source == null ? "" : source.Value.ToString(ApiConstants.DateTimeStringFormat);
            }
        }

        public class DateTimeTypeConverter : ITypeConverter<DateTime, string>
        {
            public string Convert(DateTime source, string destination, ResolutionContext context)
            {
                return source.ToString(ApiConstants.DateTimeStringFormat, CultureInfo.InvariantCulture);
            }
        }

        public class TimeSpanNullableTypeConverter : ITypeConverter<TimeSpan?, string>
        {
            public string Convert(TimeSpan? source, string destination, ResolutionContext context)
            {
                return source == null ? "" : new DateTime(source.Value.Ticks).ToString(ApiConstants.TimeFormat, CultureInfo.InvariantCulture);
            }
        }

        public class TimeSpanTypeConverter : ITypeConverter<TimeSpan, string>
        {
            public string Convert(TimeSpan source, string destination, ResolutionContext context)
            {
                return new DateTime(source.Ticks).ToString(ApiConstants.TimeFormat, CultureInfo.InvariantCulture);
            }
        }

        public class StringTypeConverter : ITypeConverter<string, string>
        {
            public string Convert(string source, string destination, ResolutionContext context)
            {
                if (!string.IsNullOrEmpty(source) && source.StartsWith("http"))
                {
                    source = source.Replace(" ", "%20");

                }

                return source;
            }
        }

        public class ListOfStringTypeConverter : ITypeConverter<string, List<string>>
        {
            public List<string> Convert(string source, List<string> destination, ResolutionContext context)
            {
                return !string.IsNullOrEmpty(source) ? source.Split(',').ToList() : null;
            }
        }

    }
}
