using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;

namespace Repository.DBModels.HotelModels
{
    public class HotelExtraPriceRepository : RepositoryBase<HotelExtraPrice>
    {
        public HotelExtraPriceRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<HotelExtraPrice> FindAll(HotelExtraPriceParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                           parameters.Fk_Hotel);

        }

        public async Task<HotelExtraPrice> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.HotelExtraPriceLangs)
                .SingleOrDefaultAsync();
        }

        public new void Create(HotelExtraPrice entity)
        {
            entity.HotelExtraPriceLangs ??= new List<HotelExtraPriceLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.HotelExtraPriceLangs.All(b => b.Language != language))
                {
                    entity.HotelExtraPriceLangs.Add(new HotelExtraPriceLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class HotelExtraPriceRepositoryExtension
    {
        public static IQueryable<HotelExtraPrice> Filter(
            this IQueryable<HotelExtraPrice> data,
            int id,
            int fk_Hotel)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                   (fk_Hotel == 0 || a.Fk_Hotel == fk_Hotel));
        }
    }
}
