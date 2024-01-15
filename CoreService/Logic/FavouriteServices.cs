using Entities.CoreServicesModels.FavouriteModels;
using Entities.DBModels.FavouriteModels;
using Microsoft.AspNetCore.Http;

namespace CoreService.Logic
{
    public class FavouriteServices
    {
        private readonly RepositoryManager _repository;

        public FavouriteServices(RepositoryManager repository)
        {
            _repository = repository;
        }

        #region FavouriteAccountHotel Services

        public IQueryable<FavouriteAccountHotelModel> GetFavouriteAccountHotels(FavouriteAccountHotelParameters parameters, LanguageEnum? language)
        {
           return _repository.FavouriteAccountHotel
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new FavouriteAccountHotelModel
                              {
                                  Id = a.Id,
                                  Fk_Account = a.Fk_Account,
                                  Fk_Hotel = a.Fk_Hotel,
                                  CreatedAt = a.CreatedAt,
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<FavouriteAccountHotelModel>> GetFavouriteAccountHotelsPaged(
            FavouriteAccountHotelParameters parameters, LanguageEnum? language)
        {
            return await PagedList<FavouriteAccountHotelModel>.ToPagedList(GetFavouriteAccountHotels(parameters, language), parameters.PageNumber, parameters.PageSize);
        }
        
        public async Task<FavouriteAccountHotel> FindFavouriteAccountHotelById(int id, bool trackChanges)
        {
            return await _repository.FavouriteAccountHotel.FindById(id, trackChanges);
        }
        
        public async Task<string> UploadFavouriteAccountHotelImage(string rootPath, IFormFile file)
        {
            FileUploader uploader = new(rootPath);
            return await uploader.UploadFile(file, "Upload/FavouriteAccountHotel");
        }

        public FavouriteAccountHotelModel GetFavouriteAccountHotelById(int id, LanguageEnum? language)
        {
            return GetFavouriteAccountHotels(new FavouriteAccountHotelParameters
            {
                Id = id,
            }, language).SingleOrDefault();
        }


        public void CreateFavouriteAccountHotel(FavouriteAccountHotel entity)
        {
            _repository.FavouriteAccountHotel.Create(entity);
        }

        public int GetFavouriteAccountHotelsCount()
        {
            return _repository.FavouriteAccountHotel.Count();
        }
        
        public int GetFavouriteAccountHotelsCount(FavouriteAccountHotelParameters parameters)
        {
            return GetFavouriteAccountHotels(parameters,  language:  null).Count();
        }

        public async Task DeleteFavouriteAccountHotel(int id)
        {
            FavouriteAccountHotel entity = await FindFavouriteAccountHotelById(id, trackChanges: false);

            _repository.FavouriteAccountHotel.Delete(entity);
        }
        
        public async Task DeleteFavouriteAccountHotel(int fk_Account, int fk_Hotel)
        {
            FavouriteAccountHotel entity = await _repository.FavouriteAccountHotel
                .FindByCondition(a => 
                    a.Fk_Account == fk_Account && a.Fk_Hotel == fk_Hotel, trackChanges: true)
                .FirstOrDefaultAsync();

            _repository.FavouriteAccountHotel.Delete(entity);
        }

        #endregion


    }
}
