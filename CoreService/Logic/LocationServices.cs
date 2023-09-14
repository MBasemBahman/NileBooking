using Entities.CoreServicesModels.LocationModels;
using Entities.DBModels.LocationModels;
using Entities.EnumData;

namespace CoreService.Logic
{
    public class LocationServices
    {
        private readonly RepositoryManager _repository;

        public LocationServices(RepositoryManager repository)
        {
            _repository = repository;
        }

        #region Area Services

        public IQueryable<AreaModel> GetAreas(
            AreaParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.Area
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new AreaModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.AreaLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  CreatedAt = a.CreatedAt,
                                  Fk_Country = a.Fk_Country,
                                  Country = new CountryModel
                                  {
                                      Id = a.Fk_Country,
                                      Name = language != null ? a.Country.CountryLangs
                                           .Where(b => b.Language == language)
                                           .Select(b => b.Name).FirstOrDefault() : a.Country.Name
                                  },
                                  HotelsCount = a.Hotels.Count
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<AreaModel>> GetAreasPaged(
            AreaParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<AreaModel>.ToPagedList(GetAreas(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Area> FindAreaById(int id, bool trackChanges)
        {
            return await _repository.Area.FindById(id, trackChanges);
        }

        public Dictionary<string, string> GetAreasLookUp(AreaParameters parameters, DBModelsEnum.LanguageEnum? otherLang)
        {
            return GetAreas(parameters, otherLang).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public AreaModel GetAreaById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetAreas(new AreaParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateArea(Area entity)
        {
            _repository.Area.Create(entity);
        }

        public int GetAreasCount()
        {
            return _repository.Area.Count();
        }

        public async Task DeleteArea(int id)
        {
            Area entity = await FindAreaById(id, trackChanges: false);

            _repository.Area.Delete(entity);
        }

        #endregion

        #region Country Services

        public IQueryable<CountryModel> GetCountries(
            CountryParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.Country
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new CountryModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.CountryLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  CreatedAt = a.CreatedAt,
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<CountryModel>> GetCountriesPaged(
            CountryParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<CountryModel>.ToPagedList(GetCountries(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Country> FindCountryById(int id, bool trackChanges)
        {
            return await _repository.Country.FindById(id, trackChanges);
        }

        public CountryModel GetCountryById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetCountries(new CountryParameters { Id = id }, language).SingleOrDefault();
        }

        public Dictionary<string, string> GetCountriesLookUp(CountryParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return GetCountries(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public void CreateCountry(Country entity)
        {
            _repository.Country.Create(entity);
        }

        public int GetCountriesCount()
        {
            return _repository.Country.Count();
        }

        public async Task DeleteCountry(int id)
        {
            Country entity = await FindCountryById(id, trackChanges: false);

            _repository.Country.Delete(entity);
        }

        #endregion
    }
}
