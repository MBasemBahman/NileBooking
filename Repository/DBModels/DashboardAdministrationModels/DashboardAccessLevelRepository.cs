using Entities.CoreServicesModels.DashboardAdministrationModels;
using Entities.DBModels.DashboardAdministrationModels;

namespace Repository.DBModels.DashboardAdministrationModels
{
    public class DashboardAccessLevelRepository : RepositoryBase<DashboardAccessLevel>
    {
        public DashboardAccessLevelRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<DashboardAccessLevel> FindAll(DashboardAccessLevelParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id, parameters.Fk_DashboardAdministrationRole,
                           parameters.Fk_DashboardView);
        }

        public async Task<DashboardAccessLevel> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                        .SingleOrDefaultAsync();
        }

        public new void Create(DashboardAccessLevel entity)
        {
            base.Create(entity);
        }
    }

    public static class DashboardAccessLevelRepositoryExtension
    {
        public static IQueryable<DashboardAccessLevel> Filter(this IQueryable<DashboardAccessLevel> data,
            int id, int fk_DashboardAdministrationRole,
            int fk_DashboardView)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
                                                    (fk_DashboardAdministrationRole == 0 || fk_DashboardView == 0 || a.Premissions.Any(b => b.Fk_DashboardAdministrationRole == fk_DashboardAdministrationRole && b.Fk_DashboardView == fk_DashboardView)) &&
                                                    (fk_DashboardAdministrationRole == 0 || a.Premissions.Any(b => b.Fk_DashboardAdministrationRole == fk_DashboardAdministrationRole)) &&
                                                    (fk_DashboardView == 0 || a.Premissions.Any(b => b.Fk_DashboardView == fk_DashboardView)));
        }
    }
}
