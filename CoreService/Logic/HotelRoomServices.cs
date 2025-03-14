﻿using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.HotelRoomModels;

namespace CoreService.Logic
{
    public class HotelRoomServices
    {
        private readonly RepositoryManager _repository;

        public HotelRoomServices(RepositoryManager repository)
        {
            _repository = repository;
        }

        #region Room Type Services

        public IQueryable<RoomTypeModel> GetRoomTypes(
            RoomTypeParameters parameters, LanguageEnum? language)
        {
            return _repository.RoomType
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new RoomTypeModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.RoomTypeLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  CreatedAt = a.CreatedAt,
                                  ColorCode = a.ColorCode
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<RoomTypeModel>> GetRoomTypesPaged(
            RoomTypeParameters parameters, LanguageEnum? language)
        {
            return await PagedList<RoomTypeModel>.ToPagedList(GetRoomTypes(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<RoomType> FindRoomTypeById(int id, bool trackChanges)
        {
            return await _repository.RoomType.FindById(id, trackChanges);
        }

        public Dictionary<string, string> GetRoomTypesLookUp(RoomTypeParameters parameters, LanguageEnum? otherLang)
        {
            return GetRoomTypes(parameters, otherLang).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public RoomTypeModel GetRoomTypeById(int id, LanguageEnum? language)
        {
            return GetRoomTypes(new RoomTypeParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateRoomType(RoomType entity)
        {
            _repository.RoomType.Create(entity);
        }

        public int GetRoomTypesCount()
        {
            return _repository.RoomType.Count();
        }

        public async Task DeleteRoomType(int id)
        {
            RoomType entity = await FindRoomTypeById(id, trackChanges: false);

            _repository.RoomType.Delete(entity);
        }

        #endregion

        #region Room Food Type Services

        public IQueryable<RoomFoodTypeModel> GetRoomFoodTypes(
            RoomFoodTypeParameters parameters, LanguageEnum? language)
        {
            return _repository.RoomFoodType
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new RoomFoodTypeModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.RoomFoodTypeLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  CreatedAt = a.CreatedAt,
                                  ColorCode = a.ColorCode,

                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<RoomFoodTypeModel>> GetRoomFoodTypesPaged(
            RoomFoodTypeParameters parameters, LanguageEnum? language)
        {
            return await PagedList<RoomFoodTypeModel>.ToPagedList(GetRoomFoodTypes(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<RoomFoodType> FindRoomFoodTypeById(int id, bool trackChanges)
        {
            return await _repository.RoomFoodType.FindById(id, trackChanges);
        }

        public Dictionary<string, string> GetRoomFoodTypesLookUp(RoomFoodTypeParameters parameters, LanguageEnum? otherLang)
        {
            return GetRoomFoodTypes(parameters, otherLang).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public RoomFoodTypeModel GetRoomFoodTypeById(int id, LanguageEnum? language)
        {
            return GetRoomFoodTypes(new RoomFoodTypeParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateRoomFoodType(RoomFoodType entity)
        {
            _repository.RoomFoodType.Create(entity);
        }

        public int GetRoomFoodTypesCount()
        {
            return _repository.RoomFoodType.Count();
        }

        public async Task DeleteRoomFoodType(int id)
        {
            RoomFoodType entity = await FindRoomFoodTypeById(id, trackChanges: false);

            _repository.RoomFoodType.Delete(entity);
        }

        #endregion

        #region Hotel Room Services

        public IQueryable<HotelRoomModel> GetHotelRooms(
            HotelRoomParameters parameters, LanguageEnum? language)
        {
            return _repository.HotelRoom
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelRoomModel
                              {
                                  Id = a.Id,
                                  Fk_Hotel = a.Fk_Hotel,
                                  Fk_RoomFoodType = a.Fk_RoomFoodType,
                                  Fk_RoomType = a.Fk_RoomType,
                                  MaxCount = a.MaxCount,
                                  BookingRoomsCount = a.BookingRooms.Count,
                                  RoomFoodType = new RoomFoodTypeModel
                                  {
                                      ColorCode = a.RoomFoodType.ColorCode,
                                      Name = language != null ? a.RoomFoodType.RoomFoodTypeLangs
                                                .Where(b => b.Language == language)
                                                .Select(b => b.Name).FirstOrDefault() : a.RoomFoodType.Name,
                                      Id = a.Fk_RoomFoodType


                                  },
                                  RoomType = new RoomTypeModel
                                  {
                                      ColorCode = a.RoomType.ColorCode,
                                      Id = a.Fk_RoomType,
                                      Name = language != null ? a.RoomType.RoomTypeLangs
                                               .Where(b => b.Language == language)
                                               .Select(b => b.Name).FirstOrDefault() : a.RoomType.Name
                                  },
                                  CreatedAt = a.CreatedAt,

                                  HotelRoomPrices = parameters.IncludeRoomPrices ?
                                  a.HotelRoomPrices.Select(b => new HotelRoomPriceModel
                                  {
                                      AdultPrice = b.AdultPrice,
                                      ChildPrice = b.ChildPrice,
                                      FromDate = b.FromDate,
                                      ToDate = b.ToDate,
                                      Fk_HotelRoom = b.Fk_HotelRoom,

                                  }).ToList()
                                  : null


                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<HotelRoomModel>> GetHotelRoomsPaged(
            HotelRoomParameters parameters, LanguageEnum? language)
        {
            return await PagedList<HotelRoomModel>.ToPagedList(GetHotelRooms(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<HotelRoom> FindHotelRoomById(int id, bool trackChanges)
        {
            return await _repository.HotelRoom.FindById(id, trackChanges);
        }

        public void AddHotelRoomPrices(int fk_HotelRoom, List<HotelRoomPriceCreateOrEditModel> prices)
        {
            if (prices != null && prices.Any())
            {
                foreach (HotelRoomPriceCreateOrEditModel price in prices)
                {
                    CreateHotelRoomPrice(new HotelRoomPrice
                    {
                        Fk_HotelRoom = fk_HotelRoom,
                        AdultPrice = price.AdultPrice,
                        ChildPrice = price.ChildPrice,
                        FromDate = price.FromDate,
                        ToDate = price.ToDate
                    });
                }
            }
        }

        public async Task RemoveHotelRoomPrices(List<int> Ids)
        {
            if (Ids != null && Ids.Any())
            {
                foreach (int id in Ids)
                {
                    await DeleteHotelRoomPrice(id);
                }
            }
        }
        
        public async Task UpdateHotelRoomPrices(int fk_HotelRoom, List<HotelRoomPriceCreateOrEditModel> hotelRoomPrices)
        {
            hotelRoomPrices ??= new List<HotelRoomPriceCreateOrEditModel>();

            List<int> oldData = _repository.HotelRoomPrice.FindAll(new HotelRoomPriceParameters
                {
                    Fk_HotelRoom = fk_HotelRoom
                }, trackChanges: false)
                .Select(a => a.Id).ToList();
            
            // List<int> oldData = GetHotelRoomPrices(new HotelRoomPriceParameters
            // {
            //     Fk_HotelRoom = fk_HotelRoom
            // }, language: null).Select(a => a.Id).ToList();

            List<int> hotelRoomPricesIds = hotelRoomPrices.Select(a => a.Id).ToList();

            List<HotelRoomPriceCreateOrEditModel> dataToCreate = hotelRoomPrices.Where(a => a.Id == 0).ToList();

            List<int> dataToRemove = oldData.Except(hotelRoomPricesIds.Where(a => a > 0)).ToList();

            AddHotelRoomPrices(fk_HotelRoom, dataToCreate);

            await RemoveHotelRoomPrices(dataToRemove);

            List<int> dataToUpdate = oldData.Where(hotelRoomPricesIds.Contains).ToList();

            if (dataToUpdate.Any())
            {
                foreach (HotelRoomPriceCreateOrEditModel data in hotelRoomPrices.Where(a => dataToUpdate.Contains(a.Id)))
                {
                    HotelRoomPrice price = await FindHotelRoomPriceById(data.Id, trackChanges: true);
                    price.AdultPrice = data.AdultPrice;
                    price.ChildPrice = data.ChildPrice;
                    price.FromDate = data.FromDate;
                    price.ToDate = data.ToDate;
                }
            }

        }
        
        public HotelRoomModel GetHotelRoomById(int id, LanguageEnum? language)
        {
            return GetHotelRooms(new HotelRoomParameters { Id = id,IncludeRoomPrices = true }, language).SingleOrDefault();
        }


        public void CreateHotelRoom(HotelRoom entity)
        {
            _repository.HotelRoom.Create(entity);
        }

        public int GetHotelRoomsCount()
        {
            return _repository.HotelRoom.Count();
        }

        public async Task DeleteHotelRoom(int id)
        {
            HotelRoom entity = await FindHotelRoomById(id, trackChanges: false);

            _repository.HotelRoom.Delete(entity);
        }

        #endregion

        #region Hotel Room Price Services

        public IQueryable<HotelRoomPriceModel> GetHotelRoomPrices(
            HotelRoomPriceParameters parameters, LanguageEnum? language)
        {
            return _repository.HotelRoomPrice
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelRoomPriceModel
                              {
                                  Id = a.Id,
                                  CreatedAt = a.CreatedAt,
                                  Fk_HotelRoom = a.Fk_HotelRoom,
                                  AdultPrice = a.AdultPrice,
                                  ChildPrice = a.ChildPrice,
                                  FromDate = a.FromDate,
                                  ToDate = a.ToDate,
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<HotelRoomPriceModel>> GetHotelRoomPricesPaged(
            HotelRoomPriceParameters parameters, LanguageEnum? language)
        {
            return await PagedList<HotelRoomPriceModel>.ToPagedList(GetHotelRoomPrices(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<HotelRoomPrice> FindHotelRoomPriceById(int id, bool trackChanges)
        {
            return await _repository.HotelRoomPrice.FindById(id, trackChanges);
        }

        public HotelRoomPriceModel GetHotelRoomPriceById(int id, LanguageEnum? language)
        {
            return GetHotelRoomPrices(new HotelRoomPriceParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateHotelRoomPrice(HotelRoomPrice entity)
        {
            _repository.HotelRoomPrice.Create(entity);
        }

        public int GetHotelRoomPricesCount()
        {
            return _repository.HotelRoomPrice.Count();
        }

        public async Task DeleteHotelRoomPrice(int id)
        {
            HotelRoomPrice entity = await FindHotelRoomPriceById(id, trackChanges: false);

            _repository.HotelRoomPrice.Delete(entity);
        }

        #endregion


    }
}
