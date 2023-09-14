using Entities.CoreServicesModels.LocationModels;
using Entities.DBModels.LocationModels;

namespace Repository.DBModels.LocationModels
{
    public class AreaRepository : RepositoryBase<Area>
    {
        public AreaRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Area> FindAll(AreaParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                           parameters.Fk_Country);
        }

        public async Task<Area> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.AreaLangs).SingleOrDefaultAsync();
        }

        public new void Create(Area entity)
        {
            entity.AreaLangs ??= new List<AreaLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.AreaLangs.All(b => b.Language != language))
                {
                    entity.AreaLangs.Add(new AreaLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class AreaRepositoryExtension
    {
        public static IQueryable<Area> Filter(
            this IQueryable<Area> data,
            int id,
            int fk_Country)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                   (fk_Country == 0 || a.Fk_Country == fk_Country));
        }
    }
}
