using Entities.CoreServicesModels.BookingModels;
using Entities.DBModels.BookingModels;
using Entities.DBModels.HotelModels;

namespace Repository.DBModels.BookingModels
{
    public class BookingRoomExtraRepository : RepositoryBase<BookingRoomExtra>
    {
        public BookingRoomExtraRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<BookingRoomExtra> FindAll(BookingRoomExtraParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_BookingRoom,
                       parameters.Fk_HotelExtra);

        }

        public async Task<BookingRoomExtra> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .SingleOrDefaultAsync();
        }

    }

    public static class BookingRoomExtraRepositoryExtension
    {
        public static IQueryable<BookingRoomExtra> Filter(
            this IQueryable<BookingRoomExtra> data,
            int id,
            int fk_BookingRoom,
            int fk_HotelExtra)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_BookingRoom == 0 || a.Fk_BookingRoom == fk_BookingRoom) &&
                                       (fk_HotelExtra == 0 || a.Fk_HotelExtra == fk_HotelExtra));
        }
    }
}
