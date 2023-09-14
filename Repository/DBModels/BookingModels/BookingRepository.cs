using Entities.CoreServicesModels.BookingModels;
using Entities.DBModels.BookingModels;

namespace Repository.DBModels.BookingModels
{
    public class BookingRepository : RepositoryBase<Booking>
    {
        public BookingRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Booking> FindAll(BookingParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_Account,
                       parameters.Fk_BookingState,
                       parameters.Fk_Hotel,
                       parameters.FromDate,
                       parameters.ToDate);

        }

        public async Task<Booking> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .SingleOrDefaultAsync();
        }

        public new void Create(Booking entity)
        {
            entity.BookingReview = new BookingReview();

            base.Create(entity);
        }

    }

    public static class BookingRepositoryExtension
    {
        public static IQueryable<Booking> Filter(
            this IQueryable<Booking> data,
            int id,
            int fk_Account,
            int fk_BookingState,
            int fk_Hotel,
            DateTime? fromDate,
            DateTime? toDate)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Account == 0 || a.Fk_Account == fk_Account) &&
                                       (fk_BookingState == 0 || a.Fk_BookingState == fk_BookingState) &&
                                       (fk_Hotel == 0 || a.Fk_Hotel == fk_Hotel) &&
                                       (fk_Account == 0 || a.Fk_Account == fk_Account) &&
                                       (fromDate == null || a.FromDate >= fromDate) &&
                                       (toDate == null || a.ToDate <= toDate));
        }
    }
}
