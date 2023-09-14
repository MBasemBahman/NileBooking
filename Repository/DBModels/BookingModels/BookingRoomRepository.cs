using Entities.CoreServicesModels.BookingModels;
using Entities.DBModels.BookingModels;

namespace Repository.DBModels.BookingModels
{
    public class BookingRoomRepository : RepositoryBase<BookingRoom>
    {
        public BookingRoomRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<BookingRoom> FindAll(BookingRoomParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_Booking,
                       parameters.Fk_HotelRoom);

        }

        public async Task<BookingRoom> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .SingleOrDefaultAsync();
        }

    }

    public static class BookingRoomRepositoryExtension
    {
        public static IQueryable<BookingRoom> Filter(
            this IQueryable<BookingRoom> data,
            int id,
            int fk_Booking,
            int fk_HotelRoom)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Booking == 0 || a.Fk_Booking == fk_Booking) &&
                                       (fk_HotelRoom == 0 || a.Fk_HotelRoom == fk_HotelRoom));
        }
    }
}
