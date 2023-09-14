using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.HotelRoomModels;

namespace Repository.DBModels.HotelRoomModels
{
    public class RoomFoodTypeRepository : RepositoryBase<RoomFoodType>
    {
        public RoomFoodTypeRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<RoomFoodType> FindAll(RoomFoodTypeParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<RoomFoodType> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.RoomFoodTypeLangs).SingleOrDefaultAsync();
        }

        public new void Create(RoomFoodType entity)
        {
            entity.RoomFoodTypeLangs ??= new List<RoomFoodTypeLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.RoomFoodTypeLangs.All(b => b.Language != language))
                {
                    entity.RoomFoodTypeLangs.Add(new RoomFoodTypeLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class RoomFoodTypeRepositoryExtension
    {
        public static IQueryable<RoomFoodType> Filter(
            this IQueryable<RoomFoodType> data,
            int id)
        {
            return data.Where(a => id == 0 || a.Id == id);
        }
    }
}
