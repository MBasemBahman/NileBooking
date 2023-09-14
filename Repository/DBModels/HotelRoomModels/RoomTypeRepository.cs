using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.HotelRoomModels;

namespace Repository.DBModels.HotelRoomModels
{
    public class RoomTypeRepository : RepositoryBase<RoomType>
    {
        public RoomTypeRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<RoomType> FindAll(RoomTypeParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<RoomType> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.RoomTypeLangs).SingleOrDefaultAsync();
        }

        public new void Create(RoomType entity)
        {
            entity.RoomTypeLangs ??= new List<RoomTypeLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.RoomTypeLangs.All(b => b.Language != language))
                {
                    entity.RoomTypeLangs.Add(new RoomTypeLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class RoomTypeRepositoryExtension
    {
        public static IQueryable<RoomType> Filter(
            this IQueryable<RoomType> data,
            int id)
        {
            return data.Where(a => id == 0 || a.Id == id);
        }
    }
}
