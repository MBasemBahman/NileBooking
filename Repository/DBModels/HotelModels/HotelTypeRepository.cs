using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;

namespace Repository.DBModels.HotelModels
{
    public class HotelTypeRepository : RepositoryBase<HotelType>
    {
        public HotelTypeRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<HotelType> FindAll(HotelTypeParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<HotelType> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.HotelTypeLangs).SingleOrDefaultAsync();
        }

        public new void Create(HotelType entity)
        {
            entity.HotelTypeLangs ??= new List<HotelTypeLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.HotelTypeLangs.All(b => b.Language != language))
                {
                    entity.HotelTypeLangs.Add(new HotelTypeLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class HotelTypeRepositoryExtension
    {
        public static IQueryable<HotelType> Filter(
            this IQueryable<HotelType> data,
            int id)
        {
            return data.Where(a => id == 0 || a.Id == id);
        }
    }
}
