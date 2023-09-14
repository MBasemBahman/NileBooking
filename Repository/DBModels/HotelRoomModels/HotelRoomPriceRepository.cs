using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.HotelRoomModels;

namespace Repository.DBModels.HotelRoomModels
{
    public class HotelRoomPriceRepository : RepositoryBase<HotelRoomPrice>
    {
        public HotelRoomPriceRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<HotelRoomPrice> FindAll(HotelRoomPriceParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_HotelRoom,
                       parameters.FromDate,
                       parameters.ToDate);

        }

        public async Task<HotelRoomPrice> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .SingleOrDefaultAsync();
        }

        public new void Create(HotelRoomPrice entity)
        {
            base.Create(entity);
        }
    }

    public static class HotelRoomPriceRepositoryExtension
    {
        public static IQueryable<HotelRoomPrice> Filter(
            this IQueryable<HotelRoomPrice> data,
            int id,
            int fk_HotelRoom,
            DateTime? fromDate,
            DateTime? toDate)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_HotelRoom == 0 || a.Fk_HotelRoom == fk_HotelRoom) &&
                                       (fromDate == null || a.FromDate >= fromDate) &&
                                       (toDate == null || a.ToDate <= toDate));
        }
    }
}
