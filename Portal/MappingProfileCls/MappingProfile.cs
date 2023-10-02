﻿#region Core Services Models
using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.LocationModels;
using Entities.CoreServicesModels.BookingModels;
using Entities.CoreServicesModels.HotelRoomModels;
using Entities.CoreServicesModels.HotelModels;
#endregion

#region Dto Models
using Portal.Areas.AccountEntity.Models;
using Portal.Areas.LocationEntity.Models;
using Portal.Areas.BookingEntity.Models;
using Portal.Areas.HotelRoomEntity.Models;
using Portal.Areas.HotelEntity.Models;
#endregion

#region DB Models
using Entities.DBModels.AccountModels;
using Entities.DBModels.LocationModels;
using Entities.DBModels.BookingModels;
using Entities.DBModels.HotelRoomModels;
using Entities.DBModels.HotelModels;
#endregion
using Entities.RequestFeatures;

namespace Portal.MappingProfileCls
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapperConfiguration configuration = new(cfg =>
            {
                cfg.AllowNullCollections = false;
            });

            CreateMap<DateTime, string>().ConvertUsing(new DateTimeTypeConverter());
            CreateMap<DateTime?, string>().ConvertUsing(new DateTimeNullableTypeConverter());
            CreateMap<TimeSpan, string>().ConvertUsing(new TimeSpanTypeConverter());
            CreateMap<TimeSpan?, string>().ConvertUsing(new TimeSpanNullableTypeConverter());
            CreateMap<string, List<string>>().ConvertUsing(new ListOfStringTypeConverter());


            _ = CreateMap<DtParameters, RequestParameters>()
                .ForMember(dest => dest.SearchTerm, opt => opt.MapFrom(src => src.Search == null ? "" : src.Search.Value))
                .ForMember(dest => dest.OrderBy, opt =>
                                   opt.MapFrom(src => src.Order == null ?
                                                      "" :
                                                      (src.Order[0].Dir.ToString().ToLower() == "asc" ?
                                                       src.Columns[src.Order[0].Column].Data :
                                                       (src.Columns[src.Order[0].Column].Data.Contains(',') ?
                                                        src.Columns[src.Order[0].Column].Data.Replace(",", " desc,") :
                                                        src.Columns[src.Order[0].Column].Data + " desc"))))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.Length > 0 ? (src.Start / src.Length) + 1 : 0))
                .IncludeAllDerived();

            // _ = CreateMap<UserAuthenticatedDto, UserDto>();


            #region Account Models

            #region Account State
            _ = CreateMap<AccountState, AccountStateCreateOrEditModel>();

            _ = CreateMap<AccountStateCreateOrEditModel, AccountState>();

            _ = CreateMap<AccountStateModel, AccountStateDto>();

            _ = CreateMap<AccountStateFilter, AccountStateParameters>();

            _ = CreateMap<AccountStateLang, AccountStateLangModel>();

            _ = CreateMap<AccountStateLangModel, AccountStateLang>();
            #endregion


            #region Account Type
            _ = CreateMap<AccountType, AccountTypeCreateOrEditModel>();

            _ = CreateMap<AccountTypeCreateOrEditModel, AccountType>();

            _ = CreateMap<AccountTypeModel, AccountTypeDto>();

            _ = CreateMap<AccountTypeFilter, AccountTypeParameters>();

            _ = CreateMap<AccountTypeLang, AccountTypeLangModel>();

            _ = CreateMap<AccountTypeLangModel, AccountTypeLang>();
            #endregion

            #endregion

            #region Location Models

            #region Area
            _ = CreateMap<Area, AreaCreateOrEditModel>();

            _ = CreateMap<AreaCreateOrEditModel, Area>();

            _ = CreateMap<AreaModel, AreaDto>();

            _ = CreateMap<AreaFilter, AreaParameters>();

            _ = CreateMap<AreaLang, AreaLangModel>();

            _ = CreateMap<AreaLangModel, AreaLang>();
            #endregion


            #region Country
            _ = CreateMap<Country, CountryCreateOrEditModel>();

            _ = CreateMap<CountryCreateOrEditModel, Country>();

            _ = CreateMap<CountryModel, CountryDto>();

            _ = CreateMap<CountryFilter, CountryParameters>();

            _ = CreateMap<CountryLang, CountryLangModel>();

            _ = CreateMap<CountryLangModel, CountryLang>();
            #endregion

            #endregion

            #region Booking Models

            #region Booking State
            _ = CreateMap<BookingState, BookingStateCreateOrEditModel>();

            _ = CreateMap<BookingStateCreateOrEditModel, BookingState>();

            _ = CreateMap<BookingStateModel, BookingStateDto>();

            _ = CreateMap<BookingStateFilter, BookingStateParameters>();

            _ = CreateMap<BookingStateLang, BookingStateLangModel>();

            _ = CreateMap<BookingStateLangModel, BookingStateLang>();
            #endregion



            #endregion

            #region Hotel Room Models

            #region Room Type
            _ = CreateMap<RoomType, RoomTypeCreateOrEditModel>();

            _ = CreateMap<RoomTypeCreateOrEditModel, RoomType>();

            _ = CreateMap<RoomTypeModel, RoomTypeDto>();

            _ = CreateMap<RoomTypeFilter, RoomTypeParameters>();

            _ = CreateMap<RoomTypeLang, RoomTypeLangModel>();

            _ = CreateMap<RoomTypeLangModel, RoomTypeLang>();
            #endregion


            #region Room Food Type
            _ = CreateMap<RoomFoodType, RoomFoodTypeCreateOrEditModel>();

            _ = CreateMap<RoomFoodTypeCreateOrEditModel, RoomFoodType>();

            _ = CreateMap<RoomFoodTypeModel, RoomFoodTypeDto>();

            _ = CreateMap<RoomFoodTypeFilter, RoomFoodTypeParameters>();

            _ = CreateMap<RoomFoodTypeLang, RoomFoodTypeLangModel>();

            _ = CreateMap<RoomFoodTypeLangModel, RoomFoodTypeLang>();
            #endregion

            #endregion

            #region Hotel Models

            #region Hotel Type
            _ = CreateMap<HotelType, HotelTypeCreateOrEditModel>();

            _ = CreateMap<HotelTypeCreateOrEditModel, HotelType>();

            _ = CreateMap<HotelTypeModel, HotelTypeDto>();

            _ = CreateMap<HotelTypeFilter, HotelTypeParameters>();

            _ = CreateMap<HotelTypeLang, HotelTypeLangModel>();

            _ = CreateMap<HotelTypeLangModel, HotelTypeLang>();
            #endregion

            #endregion



        }
    }

    public class DateTimeNullableTypeConverter : ITypeConverter<DateTime?, string>
    {
        public string Convert(DateTime? source, string destination, ResolutionContext context)
        {
            return source == null ? "" : source.Value.AddHours(2).ToString(ApiConstants.DateTimeStringFormat);
        }
    }

    public class DateTimeTypeConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            return source.AddHours(2).ToString(ApiConstants.DateTimeStringFormat);
        }
    }


    public class TimeSpanNullableTypeConverter : ITypeConverter<TimeSpan?, string>
    {
        public string Convert(TimeSpan? source, string destination, ResolutionContext context)
        {
            return source == null ? "" : new DateTime(source.Value.Ticks).ToString(ApiConstants.TimeFormat);
        }
    }

    public class TimeSpanTypeConverter : ITypeConverter<TimeSpan, string>
    {
        public string Convert(TimeSpan source, string destination, ResolutionContext context)
        {
            return new DateTime(source.Ticks).ToString(ApiConstants.TimeFormat);
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
