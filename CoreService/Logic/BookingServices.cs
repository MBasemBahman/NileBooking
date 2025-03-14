﻿using Entities.AuthenticationModels;
using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.BookingModels;
using Entities.CoreServicesModels.HotelModels;
using Entities.CoreServicesModels.HotelRoomModels;
using Entities.CoreServicesModels.LocationModels;
using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.BookingModels;

namespace CoreService.Logic
{
    public class BookingServices
    {
        private readonly RepositoryManager _repository;

        public BookingServices(RepositoryManager repository)
        {
            _repository = repository;
        }

        #region Booking State Services

        public IQueryable<BookingStateModel> GetBookingStates(
            BookingStateParameters parameters, LanguageEnum? language)
        {
            int totalBookingsCount = _repository.Booking.Count();

            return _repository.BookingState
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new BookingStateModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.BookingStateLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  CreatedAt = a.CreatedAt,
                                  BookingsCount = a.Bookings.Count,
                                  ColorCode = a.ColorCode,
                                  BookingsPercent = totalBookingsCount > 0
                                  ? (int)((double)(a.Bookings.Count / (double)totalBookingsCount) * 100)
                                  : 0,

                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<BookingStateModel>> GetBookingStatesPaged(
            BookingStateParameters parameters, LanguageEnum? language)
        {
            return await PagedList<BookingStateModel>.ToPagedList(GetBookingStates(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<BookingState> FindBookingStateById(int id, bool trackChanges)
        {
            return await _repository.BookingState.FindById(id, trackChanges);
        }

        public Dictionary<string, string> GetBookingStatesLookUp(BookingStateParameters parameters, LanguageEnum? otherLang)
        {
            return GetBookingStates(parameters, otherLang).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public BookingStateModel GetBookingStateById(int id, LanguageEnum? language)
        {
            return GetBookingStates(new BookingStateParameters { Id = id }, language).SingleOrDefault();
        }
        public void CreateBookingState(BookingState entity)
        {
            _repository.BookingState.Create(entity);
        }

        public int GetBookingStatesCount()
        {
            return _repository.BookingState.Count();
        }

        public async Task DeleteBookingState(int id)
        {
            BookingState entity = await FindBookingStateById(id, trackChanges: false);

            _repository.BookingState.Delete(entity);
        }

        #endregion

        #region Booking Services

        public IQueryable<BookingModel> GetBookings(
            BookingParameters parameters, LanguageEnum? language)
        {
            return _repository.Booking
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new BookingModel
                              {
                                  Id = a.Id,
                                  BookingState = new BookingStateModel
                                  {
                                      Name = language != null ? a.BookingState.BookingStateLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.BookingState.Name,
                                      Id = a.Fk_BookingState,
                                      ColorCode = a.BookingState.ColorCode
                                  },
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy,
                                  Fk_Account = a.Fk_Account,
                                  Discount = a.Discount,
                                  Fk_Hotel = a.Fk_Hotel,
                                  Fees = a.Fees,
                                  Fk_BookingState = a.Fk_BookingState,
                                  FromDate = a.FromDate,
                                  ToDate = a.ToDate,
                                  TotalExtraPrice = a.TotalExtraPrice,
                                  TotalRoomPrice = a.TotalRoomPrice,
                                  Hotel = new HotelModel
                                  {
                                      Id = a.Fk_Hotel,
                                      Name = language != null ? a.Hotel.HotelLangs
                                                 .Where(b => b.Language == language)
                                                 .Select(b => b.Name).FirstOrDefault() : a.Hotel.Name,
                                      ImageUrl = a.Hotel.StorageUrl + a.Hotel.ImageUrl,
                                      Address = a.Hotel.Address,
                                      Rate = a.Hotel.Rate,
                                      Fk_Area = a.Hotel.Fk_Area,
                                      Area = a.Hotel.Fk_Area != null
                                      ?
                                      new AreaModel
                                      {
                                          Name = language != null ? a.Hotel.Area.AreaLangs
                                                   .Where(b => b.Language == language)
                                                   .Select(b => b.Name).FirstOrDefault() : a.Hotel.Area.Name,

                                          Country = new CountryModel
                                          {
                                              Name = language != null ? a.Hotel.Area.Country.CountryLangs
                                                 .Where(b => b.Language == language)
                                                 .Select(b => b.Name).FirstOrDefault() : a.Hotel.Area.Country.Name
                                          }
                                      }
                                      : null,

                                  },
                                  Account = new AccountModel
                                  {
                                      ImageUrl = a.Account.StorageUrl + a.Account.ImageUrl,
                                      Fk_User = a.Account.Fk_User,
                                      Fk_AccountState = a.Account.Fk_AccountState,
                                      Fk_AccountType = a.Account.Fk_AccountType,
                                      User = new UserModel
                                      {
                                          FirstName = a.Account.User.FirstName,
                                          LastName = a.Account.User.LastName,
                                          UserName = a.Account.User.UserName,
                                          EmailAddress = a.Account.User.EmailAddress,
                                          PhoneNumber = a.Account.User.PhoneNumber,
                                      }
                                  },
                                  ImageUrl = a.StorageUrl + a.ImageUrl,
                                  BookingReview = parameters.IncludeReview && a.BookingReview != null ?
                                  new BookingReviewModel
                                  {
                                      Description = a.BookingReview.Description,
                                      Rate = a.BookingReview.Rate,
                                      CreatedAt = a.BookingReview.CreatedAt,
                                      Id = a.BookingReview.Id,

                                  }
                                  : null,
                                  TotalBookingRoomsAdultCount = a.BookingRooms.Sum(b => b.AdultCount),
                                  TotalBookingRoomsChildCount = a.BookingRooms.Sum(b => b.ChildCount),
                                  BookingRooms = parameters.IncludeRooms
                                  ? a.BookingRooms.Select(b => new BookingRoomModel
                                  {
                                      AdultCount = b.AdultCount,
                                      ChildCount = b.ChildCount,
                                      Fk_Booking = b.Fk_Booking,
                                      Fk_HotelRoom = b.Fk_HotelRoom,
                                      Id = b.Id,
                                      CreatedAt = b.CreatedAt,
                                      HotelRoom = new HotelRoomModel
                                      {
                                          Fk_Hotel = b.HotelRoom.Fk_Hotel,
                                          Fk_RoomFoodType = b.HotelRoom.Fk_RoomFoodType,
                                          Fk_RoomType = b.HotelRoom.Fk_RoomType,
                                          Id = b.HotelRoom.Id,
                                          MaxCount = b.HotelRoom.MaxCount,
                                          RoomType = new RoomTypeModel
                                          {
                                              ColorCode = b.HotelRoom.RoomType.ColorCode,
                                              Name = language != null ? b.HotelRoom.RoomType.RoomTypeLangs
                                                        .Where(c => c.Language == language)
                                                        .Select(c => c.Name).FirstOrDefault() : b.HotelRoom.RoomType.Name
                                          },
                                          RoomFoodType = new RoomFoodTypeModel
                                          {
                                              ColorCode = b.HotelRoom.RoomFoodType.ColorCode,
                                              Name = language != null ? b.HotelRoom.RoomFoodType.RoomFoodTypeLangs
                                                        .Where(c => c.Language == language)
                                                        .Select(c => c.Name).FirstOrDefault() : b.HotelRoom.RoomFoodType.Name
                                          },
                                          CreatedAt = b.HotelRoom.CreatedAt
                                      }
                                  }).ToList()
                                  : null,
                                  CanCancel = a.Fk_BookingState != (int)BookingStateEnum.Pending
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<BookingModel>> GetBookingsPaged(
            BookingParameters parameters, LanguageEnum? language)
        {
            return await PagedList<BookingModel>.ToPagedList(GetBookings(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Booking> FindBookingById(int id, bool trackChanges)
        {
            return await _repository.Booking.FindById(id, trackChanges);
        }

        public BookingModel GetBookingById(int id, LanguageEnum? language)
        {
            return GetBookings(new BookingParameters { Id = id, IncludeRooms = true }, language).SingleOrDefault();
        }


        public Booking CreateBooking(BookingCreateModel model, UserAuthenticatedDto auth)
        {
            Booking dataDb = new Booking
            {
                Fk_Account = auth.Fk_Account,
                Fk_BookingState = (int)BookingStateEnum.Pending,
                Fk_Hotel = model.Fk_Hotel,
                Fees = model.Fees,
                Discount = model.Discount,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                AdultCount = model.AdultCount,
                ChildCount = model.ChildCount
            };

            if (model.Fk_RoomTypes is { Count: > 0 })
            {
                List<HotelRoomModel> hotelRooms = _repository.HotelRoom.FindAll(new HotelRoomParameters
                {
                    Fk_Hotel = model.Fk_Hotel,
                    Fk_RoomTypes = model.Fk_RoomTypes
                }, trackChanges: false).Select(a => new HotelRoomModel
                {
                    Id = a.Id,
                    Fk_RoomType = a.Fk_RoomType
                }).ToList();
                
                dataDb.BookingRooms = new List<BookingRoom>();
                
                List<int> fk_BusyHotelRooms = new List<int>();
                
                foreach (int fk_RoomType in model.Fk_RoomTypes)
                {
                    HotelRoomModel hotelRoom = hotelRooms.FirstOrDefault(a => a.Fk_RoomType == fk_RoomType && !fk_BusyHotelRooms.Contains(a.Id));

                    if (hotelRoom == null)
                    {
                        RoomTypeEnum type = (int)RoomTypeEnum.Single == fk_RoomType ? RoomTypeEnum.Single :
                            (int)RoomTypeEnum.Double == fk_RoomType ? RoomTypeEnum.Double : RoomTypeEnum.Triple;
                        
                        throw new Exception($"Unfortunately, there is no {type} room available");
                    }
                    
                    dataDb.BookingRooms.Add(new BookingRoom
                    {
                        Fk_HotelRoom = hotelRoom.Id,
                        AdultCount = 0,
                        ChildCount = 0,
                    });

                    fk_BusyHotelRooms.Add(hotelRoom.Id);
                }
            }
            
            _repository.Booking.Create(dataDb);

            return dataDb;
        }
        
        public Booking CreateBooking(BaseBookingCreateOrEditModel model)
        {
            Booking dataDb = new Booking
            {
                Fk_Account = model.Fk_Account,
                Fk_Hotel = model.Fk_Hotel,
                Fk_BookingState = (int)BookingStateEnum.Pending,
                Fees = model.Fees,
                Discount = model.Discount,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                AdultCount = model.AdultCount,
                ChildCount = model.ChildCount,
            };

            if (model.BookingRooms is { Count: > 0 })
            {
                List<HotelRoomModel> hotelRooms = _repository.HotelRoom.FindAll(new HotelRoomParameters
                {
                    Fk_Hotel = model.Fk_Hotel,
                    Fk_RoomTypes = model.BookingRooms.Select(a => a.Fk_RoomType).ToList()
                }, trackChanges: false).Select(a => new HotelRoomModel
                {
                    Id = a.Id,
                    Fk_RoomType = a.Fk_RoomType
                }).ToList();
                
                dataDb.BookingRooms = new List<BookingRoom>();
                
                List<int> fk_BusyHotelRooms = new List<int>();
                
                foreach (BookingRoomCreateOrEditModel bookingRoom in model.BookingRooms)
                {
                    HotelRoomModel hotelRoom = hotelRooms.FirstOrDefault(a => a.Fk_RoomType == bookingRoom.Fk_RoomType && !fk_BusyHotelRooms.Contains(a.Id));
            
                    if (hotelRoom == null)
                    {
                        RoomTypeEnum type = (int)RoomTypeEnum.Single == bookingRoom.Fk_RoomType ? RoomTypeEnum.Single :
                            (int)RoomTypeEnum.Double == bookingRoom.Fk_RoomType ? RoomTypeEnum.Double : RoomTypeEnum.Triple;
                        
                        throw new Exception($"Unfortunately, there is no {type} room available");
                    }
                    
                    dataDb.BookingRooms.Add(new BookingRoom
                    {
                        Fk_HotelRoom = hotelRoom.Id,
                        AdultCount = bookingRoom.AdultCount,
                        ChildCount = bookingRoom.ChildCount,
                    });
            
                    fk_BusyHotelRooms.Add(hotelRoom.Id);
                }
            }
            
            _repository.Booking.Create(dataDb);

            return dataDb;
        }

        public void CreateBooking(Booking dataDb)
        {
            _repository.Booking.Create(dataDb);
        }
        
        public int GetBookingsCount()
        {
            return _repository.Booking.Count();
        }

        public async Task DeleteBooking(int id)
        {
            Booking entity = await FindBookingById(id, trackChanges: false);

            _repository.Booking.Delete(entity);
        }

        public double CalculateBookingPrice(BookingCreateModel booking)
        {
            double price = 0;
            if (booking.BookingRooms != null && booking.BookingRooms.Any())
            {
                foreach (var room in booking.BookingRooms)
                {
                    var hotelRoomPrice = _repository.HotelRoomPrice
                                               .FindByCondition(a => a.Fk_HotelRoom == room.Fk_HotelRoom &&
                                                               a.FromDate >= booking.FromDate &&
                                                               a.ToDate <= booking.FromDate,trackChanges:false).FirstOrDefault();

                    if (hotelRoomPrice != null)
                    {
                        price += (hotelRoomPrice.AdultPrice * room.AdultCount) + (hotelRoomPrice.ChildPrice * room.ChildCount);
                    }

                    if (room.BookingRoomExtras != null && room.BookingRoomExtras.Any())
                    {
                        price += GetBookingRoomExtras(new BookingRoomExtraParameters
                        {
                            Fk_HotelExtras = room.BookingRoomExtras.Select(a=>a.Fk_HotelExtra).ToList()
                        }, language: null).Sum(a => a.Price);
                    }
                }
            }
            if (price > booking.Discount)
            {
                price = price - booking.Discount;

            }
            return price;
        }
        #endregion

        #region Booking Review Services

        public IQueryable<BookingReviewModel> GetBookingReviews(
            BookingReviewParameters parameters)
        {
            return _repository.BookingReview
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new BookingReviewModel
                              {
                                  Id = a.Id,
                                  Fk_Booking = a.Fk_Booking,
                                  CreatedAt = a.CreatedAt,
                                  Description = a.Description,
                                  Rate = a.Rate,
                                  Account = new AccountModel
                                  {
                                      ImageUrl = a.Booking.Account.StorageUrl + a.Booking.Account.ImageUrl,
                                      Fk_User = a.Booking.Account.Fk_User,
                                      Fk_AccountState = a.Booking.Account.Fk_AccountState,
                                      Fk_AccountType = a.Booking.Account.Fk_AccountType,
                                      User = new UserModel
                                      {
                                          FirstName = a.Booking.Account.User.FirstName,
                                          LastName = a.Booking.Account.User.LastName,
                                          UserName = a.Booking.Account.User.UserName,
                                      }
                                  },
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<BookingReviewModel>> GetBookingReviewsPaged(
            BookingReviewParameters parameters)
        {
            return await PagedList<BookingReviewModel>.ToPagedList(GetBookingReviews(parameters), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<BookingReview> FindBookingReviewById(int id, bool trackChanges)
        {
            return await _repository.BookingReview.FindById(id, trackChanges);
        }

        public async Task<BookingReview> FindBookingReviewByBookingId(int fk_Booking, bool trackChanges)
        {
            return await _repository.BookingReview
                                .FindByCondition(a => a.Fk_Booking == fk_Booking, trackChanges)
                                .FirstOrDefaultAsync();
        }

        public BookingReviewModel GetBookingReviewById(int id)
        {
            return GetBookingReviews(new BookingReviewParameters { Id = id }).SingleOrDefault();
        }


        public void CreateBookingReview(BookingReview entity)
        {
            _repository.BookingReview.Create(entity);
        }

        public int GetBookingReviewsCount()
        {
            return _repository.BookingReview.Count();
        }

        public async Task DeleteBookingReview(int id)
        {
            BookingReview entity = await FindBookingReviewById(id, trackChanges: false);

            _repository.BookingReview.Delete(entity);
        }

        #endregion

        #region Booking Room Services

        public IQueryable<BookingRoomModel> GetBookingRooms(
            BookingRoomParameters parameters, LanguageEnum? language)
        {
            return _repository.BookingRoom
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new BookingRoomModel
                              {
                                  Id = a.Id,
                                  Fk_Booking = a.Fk_Booking,
                                  CreatedAt = a.CreatedAt,
                                  AdultCount = a.AdultCount,
                                  ChildCount = a.ChildCount,
                                  Fk_HotelRoom = a.Fk_HotelRoom,
                                  HotelRoom = new HotelRoomModel
                                  {
                                      Fk_Hotel = a.HotelRoom.Fk_Hotel,
                                      Fk_RoomFoodType = a.HotelRoom.Fk_RoomFoodType,
                                      Fk_RoomType = a.HotelRoom.Fk_RoomType,
                                      MaxCount = a.HotelRoom.MaxCount,
                                      RoomType = new RoomTypeModel
                                      {
                                          ColorCode = a.HotelRoom.RoomType.ColorCode,
                                          Name = language != null ? a.HotelRoom.RoomType.RoomTypeLangs
                                                    .Where(b => b.Language == language)
                                                    .Select(b => b.Name).FirstOrDefault() : a.HotelRoom.RoomType.Name
                                      },
                                      RoomFoodType = new RoomFoodTypeModel
                                      {
                                          ColorCode = a.HotelRoom.RoomFoodType.ColorCode,
                                          Name = language != null ? a.HotelRoom.RoomFoodType.RoomFoodTypeLangs
                                                    .Where(b => b.Language == language)
                                                    .Select(b => b.Name).FirstOrDefault() : a.HotelRoom.RoomFoodType.Name
                                      }
                                  },
                                  BookingRoomExtras = parameters.IncludeBookingRoomExtra ?
                                 a.BookingRoomExtras.Select(b => new BookingRoomExtraModel
                                 {

                                     Fk_BookingRoom = b.Fk_BookingRoom,
                                     Fk_HotelExtra = b.Fk_HotelExtra,
                                     Price = b.Price,
                                     Id = b.Id,
                                     HotelExtra = new HotelExtraPriceModel
                                     {
                                         Name = language != null ? b.HotelExtra.HotelExtraPriceLangs
                                                 .Where(c => c.Language == language)
                                                 .Select(c => c.Name).FirstOrDefault() : b.HotelExtra.Name,
                                         Price = b.HotelExtra.Price,
                                     }
                                 }).ToList()
                                 : null

                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<BookingRoomModel>> GetBookingRoomsPaged(
            BookingRoomParameters parameters, LanguageEnum? language)
        {
            return await PagedList<BookingRoomModel>.ToPagedList(GetBookingRooms(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<BookingRoom> FindBookingRoomById(int id, bool trackChanges)
        {
            return await _repository.BookingRoom.FindById(id, trackChanges);
        }

        public BookingRoomModel GetBookingRoomById(int id, LanguageEnum? language)
        {
            return GetBookingRooms(new BookingRoomParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateBookingRoom(BookingRoom entity)
        {
            _repository.BookingRoom.Create(entity);
        }

        public int GetBookingRoomCount()
        {
            return _repository.BookingRoom.Count();
        }

        public async Task DeleteBookingRoom(int id)
        {
            BookingRoom entity = await FindBookingRoomById(id, trackChanges: false);

            _repository.BookingRoom.Delete(entity);
        }

        #endregion

        #region Booking Room Extra Services

        public IQueryable<BookingRoomExtraModel> GetBookingRoomExtras(
            BookingRoomExtraParameters parameters, LanguageEnum? language)
        {
            return _repository.BookingRoomExtra
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new BookingRoomExtraModel
                              {
                                  Id = a.Id,
                                  Fk_BookingRoom = a.Fk_BookingRoom,
                                  Fk_HotelExtra = a.Fk_HotelExtra,
                                  Price = a.Price,
                                  CreatedAt = a.CreatedAt,
                                  HotelExtra = new HotelExtraPriceModel
                                  {
                                      Price = a.HotelExtra.Price,
                                      Name = language != null ? a.HotelExtra.HotelExtraPriceLangs
                                           .Where(b => b.Language == language)
                                           .Select(b => b.Name).FirstOrDefault() : a.HotelExtra.Name
                                  }

                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<BookingRoomExtraModel>> GetBookingRoomExtrasPaged(
            BookingRoomExtraParameters parameters, LanguageEnum? language)
        {
            return await PagedList<BookingRoomExtraModel>.ToPagedList(GetBookingRoomExtras(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<BookingRoomExtra> FindBookingRoomExtraById(int id, bool trackChanges)
        {
            return await _repository.BookingRoomExtra.FindById(id, trackChanges);
        }

        public BookingRoomExtraModel GetBookingRoomExtraById(int id, LanguageEnum? language)
        {
            return GetBookingRoomExtras(new BookingRoomExtraParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateBookingExtraRoom(BookingRoomExtra entity)
        {
            _repository.BookingRoomExtra.Create(entity);
        }

        public int GetBookingRoomExtraCount()
        {
            return _repository.BookingRoomExtra.Count();
        }

        public async Task DeleteBookingRoomExtra(int id)
        {
            BookingRoomExtra entity = await FindBookingRoomExtraById(id, trackChanges: false);

            _repository.BookingRoomExtra.Delete(entity);
        }

        #endregion

    }
}
