using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;

namespace Repository.DBModels.HotelModels
{
    public class HotelFeatureRepository : RepositoryBase<HotelFeature>
    {
        public HotelFeatureRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<HotelFeature> FindAll(HotelFeatureParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_HotelFeatureCategory);

        }

        public async Task<HotelFeature> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.HotelFeatureLangs)
                .SingleOrDefaultAsync();
        }

        public new void Create(HotelFeature entity)
        {
            entity.HotelFeatureLangs ??= new List<HotelFeatureLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.HotelFeatureLangs.All(b => b.Language != language))
                {
                    entity.HotelFeatureLangs.Add(new HotelFeatureLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class HotelFeatureRepositoryExtension
    {
        public static IQueryable<HotelFeature> Filter(
            this IQueryable<HotelFeature> data,
            int id,
            int fk_HotelFeatureCategory)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_HotelFeatureCategory == 0 || a.Fk_HotelFeatureCategory == fk_HotelFeatureCategory));
        }
    }
}
