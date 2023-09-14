using Entities.CoreServicesModels.BookingModels;
using Entities.DBModels.BookingModels;
using Entities.DBModels.HotelModels;

namespace Repository.DBModels.BookingModels
{
    public class BookingReviewRepository : RepositoryBase<BookingReview>
    {
        public BookingReviewRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<BookingReview> FindAll(BookingReviewParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_Booking);

        }

        public async Task<BookingReview> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .SingleOrDefaultAsync();
        }

    }

    public static class BookingReviewRepositoryExtension
    {
        public static IQueryable<BookingReview> Filter(
            this IQueryable<BookingReview> data,
            int id,
            int fk_Booking)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Booking == 0 || a.Fk_Booking == fk_Booking));
        }
    }
}
