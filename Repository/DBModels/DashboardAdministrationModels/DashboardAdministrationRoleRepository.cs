using Entities.CoreServicesModels.DashboardAdministrationModels;
using Entities.DBModels.DashboardAdministrationModels;

namespace Repository.DBModels.DashboardAdministrationModels
{
    public class DashboardAdministrationRoleRepository : RepositoryBase<DashboardAdministrationRole>
    {
        public DashboardAdministrationRoleRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<DashboardAdministrationRole> FindAll(DashboardAdministrationRoleRequestParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                           parameters.GetDeveloperRole);
        }

        public async Task<DashboardAdministrationRole> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                        .Include(a => a.DashboardAdministrationRoleLangs)
                        .SingleOrDefaultAsync();
        }

        public new void Create(DashboardAdministrationRole entity)
        {
            entity.DashboardAdministrationRoleLangs ??= new List<DashboardAdministrationRoleLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.DashboardAdministrationRoleLangs.All(b => b.Language != language))
                {
                    entity.DashboardAdministrationRoleLangs.Add(new DashboardAdministrationRoleLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class DashboardAdministrationRoleRepositoryExtension
    {
        public static IQueryable<DashboardAdministrationRole> Filter(this IQueryable<DashboardAdministrationRole> data,
            int id,
            bool getDeveloperRole = true)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                                           (getDeveloperRole == true || a.Id != (int)DashboardAdministrationRoleEnum.Developer));
        }
    }
}
