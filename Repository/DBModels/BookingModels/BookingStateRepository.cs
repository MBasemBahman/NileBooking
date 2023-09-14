using Entities.CoreServicesModels.BookingModels;
using Entities.DBModels.BookingModels;

namespace Repository.DBModels.BookingModels
{
    public class BookingStateRepository : RepositoryBase<BookingState>
    {
        public BookingStateRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<BookingState> FindAll(BookingStateParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<BookingState> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.BookingStateLangs).SingleOrDefaultAsync();
        }

        public new void Create(BookingState entity)
        {
            entity.BookingStateLangs ??= new List<BookingStateLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.BookingStateLangs.All(b => b.Language != language))
                {
                    entity.BookingStateLangs.Add(new BookingStateLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class BookingStateRepositoryExtension
    {
        public static IQueryable<BookingState> Filter(
            this IQueryable<BookingState> data,
            int id)
        {
            return data.Where(a => id == 0 || a.Id == id);
        }
    }
}
