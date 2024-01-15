using Entities.CoreServicesModels.FavouriteModels;
using Entities.DBModels.FavouriteModels;

namespace Repository.DBModels.FavouriteModels
{
    public class FavouriteAccountHotelRepository : RepositoryBase<FavouriteAccountHotel>
    {
        public FavouriteAccountHotelRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<FavouriteAccountHotel> FindAll(FavouriteAccountHotelParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                           parameters.Fk_Account,
                           parameters.Fk_Hotel);
        }

        public async Task<FavouriteAccountHotel> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .SingleOrDefaultAsync();
        }
    }

    public static class FavouriteAccountHotelRepositoryExtension
    {
        public static IQueryable<FavouriteAccountHotel> Filter(this IQueryable<FavouriteAccountHotel> data,
            int id,
            int fk_Account,
            int fk_Hotel)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
              (fk_Account == 0 || a.Fk_Account == fk_Account) && 
              (fk_Hotel == 0 || a.Fk_Hotel == fk_Hotel));
        }

    }
}
