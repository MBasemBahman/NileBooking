using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;

namespace Repository.DBModels.HotelModels
{
    public class HotelFeatureCategoryRepository : RepositoryBase<HotelFeatureCategory>
    {
        public HotelFeatureCategoryRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<HotelFeatureCategory> FindAll(HotelFeatureCategoryParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);

        }

        public async Task<HotelFeatureCategory> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.HotelFeatureCategoryLangs)
                .SingleOrDefaultAsync();
        }

        public new void Create(HotelFeatureCategory entity)
        {
            entity.HotelFeatureCategoryLangs ??= new List<HotelFeatureCategoryLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.HotelFeatureCategoryLangs.All(b => b.Language != language))
                {
                    entity.HotelFeatureCategoryLangs.Add(new HotelFeatureCategoryLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class HotelFeatureCategoryRepositoryExtension
    {
        public static IQueryable<HotelFeatureCategory> Filter(
            this IQueryable<HotelFeatureCategory> data,
            int id)
        {
            return data.Where(a => id == 0 || a.Id == id);
        }
    }
}
