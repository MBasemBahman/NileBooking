using Entities.CoreServicesModels.HotelModels;
using Entities.CoreServicesModels.HotelRoomModels;
using Entities.CoreServicesModels.LocationModels;
using Entities.DBModels.HotelModels;
using Entities.DBModels.HotelRoomModels;
using Microsoft.AspNetCore.Http;

namespace CoreService.Logic
{
    public class HotelServices
    {
        private readonly RepositoryManager _repository;

        public HotelServices(RepositoryManager repository)
        {
            _repository = repository;
        }

        #region Hotel Services

        public IQueryable<HotelModel> GetHotels(
            HotelParameters parameters, LanguageEnum? language)
        {
            List<HotelFeatureCategoryModel> categories = new();
            if (parameters.IncludeSelectedFeature == true)
            {
                categories = GetHotelFeatureCategories(new HotelFeatureCategoryParameters(), language)
                    .Select(a => new HotelFeatureCategoryModel
                    {
                        Id = a.Id,
                        Name = a.Name
                    }).ToList();
            }

            return _repository.Hotel
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelModel
                              {
                                  Id = a.Id,
                                  Latitude = a.Latitude,
                                  Longitude = a.Longitude,
                                  IsRecommended = a.IsRecommended,

                                  ReviewsCount = a.Bookings.Count(b => b.BookingReview != null),
                                  
                                  // Price = a.HotelRooms.Any()
                                  //     ? a.HotelRooms.SelectMany(c => c.HotelRoomPrices).OrderBy(c => c.AdultPrice).FirstOrDefault().AdultPrice
                                  //     : 0,

                                  Name = language != null ? a.HotelLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  Address = a.Address,
                                  Description = a.Description,
                                  Rate = a.Rate,
                                  BookingsCount = a.Bookings.Count,
                                  StorageUrl = a.StorageUrl,
                                  Fk_HotelType = a.Fk_HotelType,
                                  IsActive = a.IsActive,
                                  Fk_Area = a.Fk_Area,
                                  Area = a.Fk_Area != null ? new AreaModel
                                  {
                                      Name = language != null ? a.Area.AreaLangs
                                          .Where(b => b.Language == language)
                                          .Select(b => b.Name).FirstOrDefault() : a.Area.Name,
                                      Country = new CountryModel
                                      {
                                          Name = language != null ? a.Area.Country.CountryLangs
                                          .Where(b => b.Language == language)
                                          .Select(b => b.Name).FirstOrDefault() : a.Area.Country.Name,
                                      }
                                  } : null,

                                  // HotelSelectedFeatures = parameters.IncludeSelectedFeature == true ? a.HotelSelectedFeatures
                                  //     .GroupBy(b => b.HotelFeature.Fk_HotelFeatureCategory)
                                  //     .Select(group => new HotelSelectedFeaturesWithCategoryModel
                                  //     {
                                  //         Fk_HotelFeatureCategory = group.Key,
                                  //         HotelFeatureCategory = new HotelFeatureCategoryModel
                                  //         {
                                  //             Id = group.Key,
                                  //             Name = language != null ? group.FirstOrDefault().HotelFeature.HotelFeatureCategory.HotelFeatureCategoryLangs
                                  //                 .Where(c => c.Language == language)
                                  //                 .Select(d => d.Name).FirstOrDefault() : group.FirstOrDefault().HotelFeature.HotelFeatureCategory.Name,
                                  //         },
                                  //         HotelFeatures = group.Select(b => new HotelFeatureModel
                                  //         {
                                  //             Id = b.Id,
                                  //             Name = language != null ? b.HotelFeature.HotelFeatureLangs
                                  //                 .Where(c => c.Language == language)
                                  //                 .Select(d => d.Name).FirstOrDefault() : b.HotelFeature.Name,
                                  //         }).ToList()
                                  //     }).ToList() : null,
                                  HotelFeatures = parameters.IncludeSelectedFeature == true ? a.HotelSelectedFeatures
                                      .Select(b => new HotelFeatureModel
                                      {
                                          Id = b.Fk_HotelFeature,
                                          Name = language != null ? b.HotelFeature.HotelFeatureLangs
                                          .Where(c => c.Language == language)
                                          .Select(d => d.Name).FirstOrDefault() : b.HotelFeature.Name,
                                      }).ToList() : null,
                                  ImageUrl = !string.IsNullOrEmpty(a.ImageUrl) ? a.StorageUrl + a.ImageUrl : "/custom/img/hotel.jpg",
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy,
                                  AttachmentCount = a.HotelAttachments.Count,
                                  HotelType = new HotelTypeModel
                                  {
                                      Id = a.Fk_HotelType,
                                      Name = language != null ? a.HotelType.HotelTypeLangs
                                                  .Where(c => c.Language == language)
                                                  .Select(d => d.Name).FirstOrDefault() : a.HotelType.Name,
                                  },
                                  HotelExtras = parameters.IncludeExtraPrices == true
                                  ? a.HotelExtras.Select(b => new HotelExtraPriceModel
                                  {
                                      LastModifiedAt = b.LastModifiedAt,
                                      CreatedAt = b.CreatedAt,
                                      CreatedBy = b.CreatedBy,
                                      Fk_Hotel = b.Fk_Hotel,
                                      Id = b.Id,
                                      Price = b.Price,
                                      Name = language != null ? b.HotelExtraPriceLangs
                                                 .Where(c => c.Language == language)
                                                 .Select(c => c.Name).FirstOrDefault() : b.Name,
                                  
                                  }).ToList()
                                  : null,
                                  HotelRooms = parameters.IncludeRooms == true
                                  ? a.HotelRooms.Select(b => new HotelRoomModel
                                  {
                                      Fk_RoomFoodType = b.Fk_RoomFoodType,
                                      Fk_RoomType = b.Fk_RoomType,
                                      Fk_Hotel = b.Fk_Hotel,
                                      Id = b.Id,
                                      MaxCount = b.MaxCount,
                                      CreatedAt = b.CreatedAt,
                                      RoomType = new RoomTypeModel
                                      {
                                          ColorCode = b.RoomType.ColorCode,
                                          Name = language != null ? b.RoomType.RoomTypeLangs
                                                .Where(c => c.Language == language)
                                                .Select(c => c.Name).FirstOrDefault() : b.RoomType.Name
                                      },
                                      RoomFoodType = new RoomFoodTypeModel
                                      {
                                          ColorCode = b.RoomFoodType.ColorCode,
                                          Name = language != null ? b.RoomFoodType.RoomFoodTypeLangs
                                                .Where(c => c.Language == language)
                                                .Select(c => c.Name).FirstOrDefault() : b.RoomFoodType.Name
                                  
                                      }
                                  }).ToList()
                                  : null,
                                  HotelAttachments = parameters.IncludeAttachments == true
                                  ? a.HotelAttachments.Select(b => new HotelAttachmentModel
                                  {
                                      FileLength = b.FileLength,
                                      FileName = b.FileName,
                                      FileType = b.FileType,
                                      FileUrl = b.StorageUrl + b.FileUrl,
                                      CreatedAt = b.CreatedAt,
                                      CreatedBy = b.CreatedBy,
                                      Fk_Hotel = b.Fk_Hotel,
                                      Id = b.Id
                                  
                                  }).ToList()
                                  : null,

                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<HotelModel>> GetHotelsPaged(
            HotelParameters parameters, LanguageEnum? language)
        {
            return await PagedList<HotelModel>.ToPagedList(GetHotels(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Hotel> FindHotelById(int id, bool trackChanges)
        {
            return await _repository.Hotel.FindById(id, trackChanges);
        }

        public async Task<string> UploadHotelImage(string rootPath, IFormFile file)
        {
            FileUploader uploader = new(rootPath);
            return await uploader.UploadFile(file, "Upload/Hotel");
        }
        
        public Dictionary<string, string> GetHotelsLookUp(HotelParameters parameters, LanguageEnum? language)
        {
            return GetHotels(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public HotelModel GetHotelById(int id, LanguageEnum? language)
        {
            return GetHotels(new HotelParameters
            {
                Id = id,
                IncludeSelectedFeature = true
            }, language).SingleOrDefault();
        }


        public void CreateHotel(Hotel entity)
        {
            _repository.Hotel.Create(entity);
        }

        public int GetHotelsCount()
        {
            return _repository.Hotel.Count();
        }
        
        public int GetHotelsCount(HotelParameters parameters)
        {
            return GetHotels(parameters,  language:  null).Count();
        }

        public async Task DeleteHotel(int id)
        {
            Hotel entity = await FindHotelById(id, trackChanges: false);

            _repository.Hotel.Delete(entity);
        }

        #endregion

        #region Hotel Attachment Services

        public IQueryable<HotelAttachmentModel> GetHotelAttachments(
            HotelAttachmentParameters parameters, LanguageEnum? language)
        {
            return _repository.HotelAttachment
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelAttachmentModel
                              {
                                  Id = a.Id,
                                  Fk_Hotel = a.Fk_Hotel,
                                  Hotel = new HotelModel
                                  {
                                      Name = language != null ? a.Hotel.HotelLangs
                                          .Where(b => b.Language == language)
                                          .Select(b => b.Name).FirstOrDefault() : a.Hotel.Name,
                                  },
                                  FileUrl = a.StorageUrl + a.FileUrl,
                                  FileLength = a.FileLength,
                                  FileName = a.FileName,
                                  FileType = a.FileType,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<HotelAttachmentModel>> GetHotelAttachmentsPaged(
            HotelAttachmentParameters parameters, LanguageEnum? language)
        {
            return await PagedList<HotelAttachmentModel>.ToPagedList(GetHotelAttachments(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<HotelAttachment> FindHotelAttachmentById(int id, bool trackChanges)
        {
            return await _repository.HotelAttachment.FindById(id, trackChanges);
        }

        public async Task<HotelAttachment> UploadHotelAttachment(string rootPath, IFormFile file)
        {
            FileUploader uploader = new(rootPath);

            return new HotelAttachment
            {
                FileUrl = await uploader.UploadFile(file, "Uploud/HotelAttachment"),
                FileLength = file.Length,
                FileName = file.FileName,
                FileType = file.ContentType,
            };
        }

        public HotelAttachmentModel GetHotelAttachmentById(int id, LanguageEnum? language)
        {
            return GetHotelAttachments(new HotelAttachmentParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateHotelAttachment(HotelAttachment entity)
        {
            _repository.HotelAttachment.Create(entity);
        }

        public int GetHotelAttachmentsCount()
        {
            return _repository.HotelAttachment.Count();
        }

        public async Task DeleteHotelAttachment(int id)
        {
            HotelAttachment entity = await FindHotelAttachmentById(id, trackChanges: false);

            _repository.HotelAttachment.Delete(entity);
        }

        #endregion

        #region Hotel Feature Services

        public IQueryable<HotelFeatureModel> GetHotelFeatures(
            HotelFeatureParameters parameters, LanguageEnum? language)
        {
            return _repository.HotelFeature
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelFeatureModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.HotelFeatureLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  Fk_HotelFeatureCategory = a.Fk_HotelFeatureCategory,
                                  HotelFeatureCategory = new HotelFeatureCategoryModel
                                  {
                                      Name = language != null ? a.HotelFeatureCategory.HotelFeatureCategoryLangs
                                          .Where(b => b.Language == language)
                                          .Select(b => b.Name).FirstOrDefault() : a.HotelFeatureCategory.Name,
                                  },
                                  ImageUrl = a.StorageUrl + a.ImageUrl,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<HotelFeatureModel>> GetHotelFeaturesPaged(
            HotelFeatureParameters parameters, LanguageEnum? language)
        {
            return await PagedList<HotelFeatureModel>.ToPagedList(GetHotelFeatures(parameters, language), parameters.PageNumber, parameters.PageSize);
        }


        public Dictionary<string, string> GetHotelFeaturesLookUp(HotelFeatureParameters parameters, LanguageEnum? language)
        {
            return GetHotelFeatures(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public void UpdateHotelFeatures(int fk_Hotel, List<int> hotelFeatures)
        {
            if (hotelFeatures == null || !hotelFeatures.Any())
            {
                return;
            }

            List<int> oldIds = _repository.HotelSelectedFeatures.FindAll(new HotelSelectedFeaturesParameters
            {
                Fk_Hotel = fk_Hotel
            }, trackChanges: false).Select(a => a.Fk_HotelFeature).ToList();

            List<int> newIds = hotelFeatures.Except(oldIds).ToList();

            foreach (int fk_HotelFeature in newIds)
            {
                _repository.HotelSelectedFeatures.Create(new HotelSelectedFeatures
                {
                    Fk_Hotel = fk_Hotel,
                    Fk_HotelFeature = fk_HotelFeature,
                });
            }

            List<int> removedIds = oldIds.Except(hotelFeatures).ToList();

            foreach (int fk_HotelFeature in removedIds)
            {
                HotelSelectedFeatures entity = _repository.HotelSelectedFeatures
                    .FindAll(new HotelSelectedFeaturesParameters
                    {
                        Fk_Hotel = fk_Hotel,
                        Fk_HotelFeature = fk_HotelFeature
                    }, trackChanges: false)
                    .FirstOrDefault();

                _repository.HotelSelectedFeatures.Delete(entity);
            }
        }

        public async Task<HotelFeature> FindHotelFeatureById(int id, bool trackChanges)
        {
            return await _repository.HotelFeature.FindById(id, trackChanges);
        }

        public HotelFeatureModel GetHotelFeatureById(int id, LanguageEnum? language)
        {
            return GetHotelFeatures(new HotelFeatureParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateHotelFeature(HotelFeature entity)
        {
            _repository.HotelFeature.Create(entity);
        }

        public int GetHotelFeaturesCount()
        {
            return _repository.HotelFeature.Count();
        }

        public async Task DeleteHotelFeature(int id)
        {
            HotelFeature entity = await FindHotelFeatureById(id, trackChanges: false);

            _repository.HotelFeature.Delete(entity);
        }

        #endregion

        #region Hotel Feature Category Services

        public IQueryable<HotelFeatureCategoryModel> GetHotelFeatureCategories(
            HotelFeatureCategoryParameters parameters, LanguageEnum? language)
        {
            int hotalFeaturesTotalCount = _repository.HotelFeature.Count();

            return _repository.HotelFeatureCategory
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelFeatureCategoryModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.HotelFeatureCategoryLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  HotelFeaturesCount = a.HotelFeatures.Count,
                                  HotelFeatures = parameters.IncludeHotelFeatures == true ?
                                      a.HotelFeatures.Select(b => new HotelFeatureModel
                                      {
                                          Id = b.Id,
                                          Name = language != null ? b.HotelFeatureLangs
                                              .Where(c => c.Language == language)
                                              .Select(c => c.Name).FirstOrDefault() : b.Name,
                                      }).ToList() : null,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy,
                                  HotelFeaturesPercent = hotalFeaturesTotalCount > 0
                                  ? (int)((double)(a.HotelFeatures.Count / (double)hotalFeaturesTotalCount) * 100)
                                  : 0,

                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<HotelFeatureCategoryModel>> GetHotelFeatureCategoriesPaged(
            HotelFeatureCategoryParameters parameters, LanguageEnum? language)
        {
            return await PagedList<HotelFeatureCategoryModel>.ToPagedList(GetHotelFeatureCategories(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<HotelFeatureCategory> FindHotelFeatureCategoryById(int id, bool trackChanges)
        {
            return await _repository.HotelFeatureCategory.FindById(id, trackChanges);
        }

        public Dictionary<string, string> GetHotelFeatureCategorysLookUp(HotelFeatureCategoryParameters parameters, LanguageEnum? language)
        {
            return GetHotelFeatureCategories(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public HotelFeatureCategoryModel GetHotelFeatureCategoryById(int id, LanguageEnum? language)
        {
            return GetHotelFeatureCategories(new HotelFeatureCategoryParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateHotelFeatureCategory(HotelFeatureCategory entity)
        {
            _repository.HotelFeatureCategory.Create(entity);
        }

        public int GetHotelFeatureCategoriesCount()
        {
            return _repository.HotelFeatureCategory.Count();
        }

        public async Task DeleteHotelFeatureCategory(int id)
        {
            HotelFeatureCategory entity = await FindHotelFeatureCategoryById(id, trackChanges: false);

            _repository.HotelFeatureCategory.Delete(entity);
        }

        #endregion

        #region Hotel Selected Features Services

        public IQueryable<HotelSelectedFeaturesModel> GetHotelSelectedFeatures(
            HotelSelectedFeaturesParameters parameters, LanguageEnum? language)
        {
            return _repository.HotelSelectedFeatures
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelSelectedFeaturesModel
                              {
                                  Id = a.Id,
                                  Fk_Hotel = a.Fk_Hotel,
                                  Fk_HotelFeature = a.Fk_HotelFeature,
                                  CreatedAt = a.CreatedAt,

                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<HotelSelectedFeaturesModel>> GetHotelSelectedFeaturesPaged(
            HotelSelectedFeaturesParameters parameters, LanguageEnum? language)
        {
            return await PagedList<HotelSelectedFeaturesModel>.ToPagedList(GetHotelSelectedFeatures(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<HotelSelectedFeatures> FindHotelSelectedFeaturesById(int id, bool trackChanges)
        {
            return await _repository.HotelSelectedFeatures.FindById(id, trackChanges);
        }

        public HotelSelectedFeaturesModel GetHotelSelectedFeaturesById(int id, LanguageEnum? language)
        {
            return GetHotelSelectedFeatures(new HotelSelectedFeaturesParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateHotelSelectedFeatures(HotelSelectedFeatures entity)
        {
            _repository.HotelSelectedFeatures.Create(entity);
        }

        public int GetHotelSelectedFeaturesCount()
        {
            return _repository.HotelSelectedFeatures.Count();
        }

        public async Task DeleteHotelSelectedFeatures(int id)
        {
            HotelSelectedFeatures entity = await FindHotelSelectedFeaturesById(id, trackChanges: false);

            _repository.HotelSelectedFeatures.Delete(entity);
        }

        #endregion

        #region Hotel Type Services
        public IQueryable<HotelTypeModel> GetHotelTypes(
            HotelTypeParameters parameters, LanguageEnum? language)
        {
            int totalHotelsCount = _repository.Hotel.Count();

            return _repository.HotelType
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelTypeModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.HotelTypeLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  CreatedAt = a.CreatedAt,
                                  HotelsCount = a.Hotels.Count,
                                  HotelsPercent = totalHotelsCount > 0
                                  ? (int)((double)(a.Hotels.Count / (double)totalHotelsCount) * 100)
                                  : 0,

                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<HotelTypeModel>> GetHotelTypesPaged(
            HotelTypeParameters parameters, LanguageEnum? language)
        {
            return await PagedList<HotelTypeModel>.ToPagedList(GetHotelTypes(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<HotelType> FindHotelTypeById(int id, bool trackChanges)
        {
            return await _repository.HotelType.FindById(id, trackChanges);
        }

        public Dictionary<string, string> GetHotelTypesLookUp(HotelTypeParameters parameters, LanguageEnum? otherLang)
        {
            return GetHotelTypes(parameters, otherLang).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public HotelTypeModel GetHotelTypeById(int id, LanguageEnum? language)
        {
            return GetHotelTypes(new HotelTypeParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateHotelType(HotelType entity)
        {
            _repository.HotelType.Create(entity);
        }

        public int GetHotelTypesCount()
        {
            return _repository.HotelType.Count();
        }

        public async Task DeleteHotelType(int id)
        {
            HotelType entity = await FindHotelTypeById(id, trackChanges: false);

            _repository.HotelType.Delete(entity);
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
                                  Fk_RoomFoodType = a.Fk_RoomFoodType,
                                  RoomFoodType = new RoomFoodTypeModel
                                  {
                                      Name = language != null ? a.RoomFoodType.RoomFoodTypeLangs
                                          .Where(b => b.Language == language)
                                          .Select(b => b.Name).FirstOrDefault() : a.RoomFoodType.Name,
                                  },
                                  Fk_RoomType = a.Fk_RoomType,
                                  RoomType = new RoomTypeModel
                                  {
                                      Name = language != null ? a.RoomType.RoomTypeLangs
                                          .Where(b => b.Language == language)
                                          .Select(b => b.Name).FirstOrDefault() : a.RoomType.Name,
                                  },
                                  MaxCount = a.MaxCount,
                                  BookingRoomsCount = a.BookingRooms.Count,
                                  CreatedAt = a.CreatedAt,
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

        public HotelRoomModel GetHotelRoomById(int id, LanguageEnum? language)
        {
            return GetHotelRooms(new HotelRoomParameters { Id = id }, language).SingleOrDefault();
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

        #region Hotel Extra Price Services

        public IQueryable<HotelExtraPriceModel> GetHotelExtraPrices(
            HotelExtraPriceParameters parameters, LanguageEnum? language)
        {
            return _repository.HotelExtraPrice
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelExtraPriceModel
                              {
                                  Id = a.Id,
                                  Fk_Hotel = a.Fk_Hotel,
                                  Hotel = new HotelModel
                                  {
                                      Name = language != null ? a.Hotel.HotelLangs
                                          .Where(b => b.Language == language)
                                          .Select(b => b.Name).FirstOrDefault() : a.Hotel.Name,
                                  },
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy,
                                  Price = a.Price,
                                  Name = language != null ? a.HotelExtraPriceLangs
                                               .Where(a => a.Language == language)
                                               .Select(a => a.Name).FirstOrDefault() : a.Name
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<HotelExtraPriceModel>> GetHotelExtraPricesPaged(
            HotelExtraPriceParameters parameters, LanguageEnum? language)
        {
            return await PagedList<HotelExtraPriceModel>.ToPagedList(GetHotelExtraPrices(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<HotelExtraPrice> FindHotelExtraPriceById(int id, bool trackChanges)
        {
            return await _repository.HotelExtraPrice.FindById(id, trackChanges);
        }

        public HotelExtraPriceModel GetHotelExtraPriceById(int id, LanguageEnum? language)
        {
            return GetHotelExtraPrices(new HotelExtraPriceParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateHotelExtraPrice(HotelExtraPrice entity)
        {
            _repository.HotelExtraPrice.Create(entity);
        }

        public int GetHotelExtraPricesCount()
        {
            return _repository.HotelExtraPrice.Count();
        }

        public async Task DeleteHotelExtraPrice(int id)
        {
            HotelExtraPrice entity = await FindHotelExtraPriceById(id, trackChanges: false);

            _repository.HotelExtraPrice.Delete(entity);
        }

        #endregion


    }
}
