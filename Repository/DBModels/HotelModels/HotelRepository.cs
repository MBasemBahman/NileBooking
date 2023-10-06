using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;

namespace Repository.DBModels.HotelModels
{
    public class HotelRepository : RepositoryBase<Hotel>
    {
        public HotelRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Hotel> FindAll(HotelParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_HotelType,
                       parameters.Fk_Country,
                       parameters.Fk_Area,
                       parameters.Fk_HotelFeatureCategories,
                       parameters.Fk_HotelFeatures,
                       parameters.Fk_RoomTypes,
                       parameters.Fk_RoomFoodTypes,
                       parameters.IsActive,
                       parameters.IsRecommended,
                       parameters.TxtSearch);

        }

        public async Task<Hotel> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.HotelLangs)
                .SingleOrDefaultAsync();
        }

        public new void Create(Hotel entity)
        {
            entity.HotelLangs ??= new List<HotelLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.HotelLangs.All(b => b.Language != language))
                {
                    entity.HotelLangs.Add(new HotelLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class HotelRepositoryExtension
    {
        public static IQueryable<Hotel> Filter(
            this IQueryable<Hotel> data,
            int id,
            int fk_HotelType,
            int fk_Country,
            int fk_Area,
           List<int> fk_HotelFeatureCategories,
           List<int> fk_HotelFeatures,
           List<int> fk_RoomTypes,
           List<int> fk_RoomFoodTypes,
            bool? isActive,
            bool? isRecommended,
            string txtSearch)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                       (string.IsNullOrEmpty(txtSearch) || a.Name.Contains(txtSearch) ||
                                        a.HotelType.Name.Contains(txtSearch)) &&
                                       (fk_HotelType == 0 || a.Fk_HotelType == fk_HotelType) &&
                                       (fk_Country == 0 || a.Area.Fk_Country == fk_Country) &&
                                       (fk_Area == 0 || a.Fk_Area == fk_Area) &&
                                       (fk_HotelFeatureCategories == null || !fk_HotelFeatureCategories.Any() || a.HotelSelectedFeatures.Any(b => fk_HotelFeatureCategories.Contains(b.HotelFeature.Fk_HotelFeatureCategory))) &&
                                       (fk_HotelFeatures == null || !fk_HotelFeatures.Any() || a.HotelSelectedFeatures.Any(b => fk_HotelFeatures.Contains(b.Fk_HotelFeature))) &&
                                       (fk_RoomTypes == null || !fk_RoomTypes.Any() || a.HotelRooms.Any(b => fk_RoomTypes.Contains(b.Fk_RoomType))) &&
                                       (fk_RoomFoodTypes == null || !fk_RoomFoodTypes.Any() || a.HotelRooms.Any(b => fk_RoomFoodTypes.Contains(b.Fk_RoomFoodType))) &&
                                       (isActive == null || a.IsActive == isActive) &&
                                       (isRecommended == null || a.IsRecommended == isRecommended));
        }
    }
}
