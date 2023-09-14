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
                       parameters.IsActive);

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
            bool? isActive)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_HotelType == 0 || a.Fk_HotelType == fk_HotelType) &&
                                       (fk_Country == 0 || a.Area.Fk_Country == fk_Country) &&
                                       (fk_Area == 0 || a.Fk_Area == fk_Area) &&
                                       (isActive == null || a.IsActive == isActive));
        }
    }
}
