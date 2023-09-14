using Entities.CoreServicesModels.LocationModels;
using Entities.DBModels.LocationModels;

namespace Repository.DBModels.LocationModels
{
    public class CountryRepository : RepositoryBase<Country>
    {
        public CountryRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Country> FindAll(CountryParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<Country> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.CountryLangs).SingleOrDefaultAsync();
        }

        public new void Create(Country entity)
        {
            entity.CountryLangs ??= new List<CountryLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.CountryLangs.All(b => b.Language != language))
                {
                    entity.CountryLangs.Add(new CountryLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class CountryRepositoryExtension
    {
        public static IQueryable<Country> Filter(
            this IQueryable<Country> data,
            int id)
        {
            return data.Where(a => id == 0 || a.Id == id);
        }
    }
}
