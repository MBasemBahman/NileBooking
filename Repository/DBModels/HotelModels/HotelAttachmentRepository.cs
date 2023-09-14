using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;

namespace Repository.DBModels.HotelModels
{
    public class HotelAttachmentRepository : RepositoryBase<HotelAttachment>
    {
        public HotelAttachmentRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<HotelAttachment> FindAll(HotelAttachmentParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_Hotel);

        }

        public async Task<HotelAttachment> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(HotelAttachment entity)
        {
            base.Create(entity);
        }
    }

    public static class HotelAttachmentRepositoryExtension
    {
        public static IQueryable<HotelAttachment> Filter(
            this IQueryable<HotelAttachment> data,
            int id,
            int fk_Hotel)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Hotel == 0 || a.Fk_Hotel == fk_Hotel));
        }
    }
}
