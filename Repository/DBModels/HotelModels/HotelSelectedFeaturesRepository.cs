using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;

namespace Repository.DBModels.HotelModels
{
    public class HotelSelectedFeaturesRepository : RepositoryBase<HotelSelectedFeatures>
    {
        public HotelSelectedFeaturesRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<HotelSelectedFeatures> FindAll(HotelSelectedFeaturesParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_Hotel,
                       parameters.Fk_HotelFeature);

        }

        public async Task<HotelSelectedFeatures> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(HotelSelectedFeatures entity)
        {
            base.Create(entity);
        }
    }

    public static class HotelSelectedFeaturesRepositoryExtension
    {
        public static IQueryable<HotelSelectedFeatures> Filter(
            this IQueryable<HotelSelectedFeatures> data,
            int id,
            int fk_Hotel,
            int fk_HotelFeature)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Hotel == 0 || a.Fk_Hotel == fk_Hotel) &&
                                       (fk_HotelFeature == 0 || a.Fk_HotelFeature == fk_HotelFeature));
        }
    }
}
