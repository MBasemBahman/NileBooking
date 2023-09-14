using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;

namespace Repository.DBModels.AccountModels
{
    public class AccountTypeRepository : RepositoryBase<AccountType>
    {
        public AccountTypeRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<AccountType> FindAll(AccountTypeParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<AccountType> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.AccountTypeLangs).SingleOrDefaultAsync();
        }

        public new void Create(AccountType entity)
        {
            entity.AccountTypeLangs ??= new List<AccountTypeLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.AccountTypeLangs.All(b => b.Language != language))
                {
                    entity.AccountTypeLangs.Add(new AccountTypeLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class AccountTypeRepositoryExtension
    {
        public static IQueryable<AccountType> Filter(
            this IQueryable<AccountType> data,
            int id)
        {
            return data.Where(a => id == 0 || a.Id == id);
        }
    }
}
