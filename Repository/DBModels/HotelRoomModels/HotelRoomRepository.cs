using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.HotelRoomModels;

namespace Repository.DBModels.HotelRoomModels
{
    public class HotelRoomRepository : RepositoryBase<HotelRoom>
    {
        public HotelRoomRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<HotelRoom> FindAll(HotelRoomParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_Hotel,
                       parameters.Fk_RoomFoodType,
                       parameters.Fk_RoomTypes,
                       parameters.Fk_RoomType);

        }

        public async Task<HotelRoom> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .SingleOrDefaultAsync();
        }

    }

    public static class HotelRoomRepositoryExtension
    {
        public static IQueryable<HotelRoom> Filter(
            this IQueryable<HotelRoom> data,
            int id,
            int fk_Hotel,
            int fk_RoomFoodType,
            List<int> fk_RoomTypes,
            int fk_RoomType)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Hotel == 0 || a.Fk_Hotel == fk_Hotel) &&
                                       (fk_RoomFoodType == 0 || a.Fk_RoomFoodType == fk_RoomFoodType) &&
                                       (fk_RoomTypes == null || !fk_RoomTypes.Any() || fk_RoomTypes.Contains(a.Fk_RoomType)) &&
                                       (fk_RoomType == 0 || a.Fk_RoomType == fk_RoomType));
        }
    }
}
