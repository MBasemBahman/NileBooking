using Entities.AuthenticationModels;
using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.AccountModels;
using Microsoft.AspNetCore.Http;

namespace CoreService.Logic
{
    public class AccountServices
    {
        private readonly RepositoryManager _repository;

        public AccountServices(RepositoryManager repository)
        {
            _repository = repository;
        }

        #region Account Services

        public IQueryable<AccountModel> GetAccounts(
            AccountParameters parameters, LanguageEnum? language)
        {
            return _repository.Account
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new AccountModel
                              {
                                  Id = a.Id,
                                  Fk_User = a.Fk_User,
                                  User = new UserModel
                                  {
                                      FirstName = a.User.FirstName,
                                      LastName = a.User.LastName,
                                      FullName = a.User.FullName,
                                      EmailAddress = a.User.EmailAddress,
                                      PhoneNumber = a.User.PhoneNumber,
                                      AppleToken = a.User.AppleToken,
                                      Id = a.Fk_User,
                                      CreatedBy = a.User.CreatedBy,
                                      CreatedAt = a.User.CreatedAt,
                                      LastModifiedAt = a.User.LastModifiedAt,
                                      Culture = a.User.Culture,
                                      UserName = a.User.UserName,
                                      IsExternalLogin = a.User.IsExternalLogin,
                                  },
                                  ImageUrl = a.StorageUrl + a.ImageUrl,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy,
                                  AccountState = new AccountStateModel
                                  {
                                      Name = language != null ? a.AccountState.AccountStateLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.AccountState.Name,
                                      ColorCode = a.AccountState.ColorCode
                                  },
                                  Fk_AccountState = a.Fk_AccountState,
                                  Fk_AccountType = a.Fk_AccountType,
                                  AccountType = new AccountTypeModel
                                  {
                                      Name = language != null ? a.AccountType.AccountTypeLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.AccountType.Name,
                                      ColorCode = a.AccountType.ColorCode
                                  },
                                  BookingsCount = a.Bookings.Count,
                                  StorageUrl = a.StorageUrl
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<UserAuthenticatedDto> GetAuthenticatedUser(int fK_User, LanguageEnum? language)
        {
            return await GetAccounts(new AccountParameters { Fk_User = fK_User }, language)
                        .Select(a => new UserAuthenticatedDto
                        {
                            CreatedAt = a.CreatedAt,
                            EmailAddress = a.User.EmailAddress,
                            Fk_Account = a.Id,
                            Fk_AccountState = a.Fk_AccountState,
                            Fk_AccountType = a.Fk_AccountType,
                            Id = a.User.Id,
                            ImageUrl = a.ImageUrl,
                            Name = a.User.FullName,
                            PhoneNumber = a.User.PhoneNumber,
                            UserName = a.User.UserName,
                        })
                        .FirstOrDefaultAsync();
        }

        public async Task<PagedList<AccountModel>> GetAccountsPaged(
            AccountParameters parameters, LanguageEnum? language)
        {
            return await PagedList<AccountModel>.ToPagedList(GetAccounts(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Account> FindAccountById(int id, bool trackChanges)
        {
            return await _repository.Account.FindById(id, trackChanges);
        }

        public async Task<string> UploadAccountImage(string rootPath, IFormFile file)
        {
            FileUploader uploader = new(rootPath);
            return await uploader.UploadFile(file, "Upload/Account");
        }

        public Dictionary<string, string> GetAccountsLookUp(AccountParameters parameters, LanguageEnum? language)
        {
            return GetAccounts(parameters, language).ToDictionary(a => a.Id.ToString(), a => $"{a.User.FirstName} {a.User.LastName}");
        }

        public AccountModel GetAccountById(int id, LanguageEnum? language)
        {
            return GetAccounts(new AccountParameters { Id = id }, language).SingleOrDefault();
        }

        public AccountModel GetByUserId(int fk_User, LanguageEnum? language)
        {
            return GetAccounts(new AccountParameters { Fk_User = fk_User }, language).SingleOrDefault();
        }




        public void CreateAccount(Account entity)
        {
            if (entity.User != null)
            {
                entity.User.Password = GeneratePassword(entity.User.Password);
            }
            _repository.Account.Create(entity);
        }

        public string GeneratePassword(string password)
        {
            return BC.HashPassword(password);
        }

        public int GetAccountsCount()
        {
            return _repository.Account.Count();
        }

        public async Task DeleteAccount(int id)
        {
            Account entity = await FindAccountById(id, trackChanges: false);

            _repository.Account.Delete(entity);
        }

        #endregion

        #region Account Type Services

        public IQueryable<AccountTypeModel> GetAccountTypes(
            AccountTypeParameters parameters, LanguageEnum? language)
        {
            int totalAccountCount = _repository.Account.Count();

            return _repository.AccountType
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new AccountTypeModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.AccountTypeLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  ColorCode = a.ColorCode,
                                  CreatedAt = a.CreatedAt,
                                  AccountsCount = a.Accounts.Count,
                                  AccountsPercent = totalAccountCount > 0
                                  ? (int)((double)(a.Accounts.Count / (double)totalAccountCount) * 100)
                                  : 0,

                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<AccountTypeModel>> GetAccountTypesPaged(
            AccountTypeParameters parameters, LanguageEnum? language)
        {
            return await PagedList<AccountTypeModel>.ToPagedList(GetAccountTypes(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<AccountType> FindAccountTypeById(int id, bool trackChanges)
        {
            return await _repository.AccountType.FindById(id, trackChanges);
        }

        public Dictionary<string, string> GetAccountTypesLookUp(AccountTypeParameters parameters, LanguageEnum? otherLang)
        {
            return GetAccountTypes(parameters, otherLang).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public AccountTypeModel GetAccountTypeById(int id, LanguageEnum? language)
        {
            return GetAccountTypes(new AccountTypeParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateAccountType(AccountType entity)
        {
            _repository.AccountType.Create(entity);
        }

        public int GetAccountTypesCount()
        {
            return _repository.AccountType.Count();
        }

        public async Task DeleteAccountType(int id)
        {
            AccountType entity = await FindAccountTypeById(id, trackChanges: false);

            _repository.AccountType.Delete(entity);
        }

        #endregion

        #region Account State Services

        public IQueryable<AccountStateModel> GetAccountStates(
            AccountStateParameters parameters, LanguageEnum? language)
        {
            int totalAccountCount = _repository.Account.Count();

            return _repository.AccountState
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new AccountStateModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.AccountStateLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  ColorCode = a.ColorCode,
                                  CreatedAt = a.CreatedAt,
                                  AccountsCount = a.Accounts.Count,
                                  AccountsPercent = totalAccountCount > 0
                                  ? (int)((double)(a.Accounts.Count / (double)totalAccountCount) * 100)
                                  : 0,
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<AccountStateModel>> GetAccountStatesPaged(
            AccountStateParameters parameters, LanguageEnum? language)
        {
            return await PagedList<AccountStateModel>.ToPagedList(GetAccountStates(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<AccountState> FindAccountStateById(int id, bool trackChanges)
        {
            return await _repository.AccountState.FindById(id, trackChanges);
        }

        public AccountStateModel GetAccountStateById(int id, LanguageEnum? language)
        {
            return GetAccountStates(new AccountStateParameters { Id = id }, language).SingleOrDefault();
        }

        public Dictionary<string, string> GetAccountStatesLookUp(AccountStateParameters parameters, LanguageEnum? language)
        {
            return GetAccountStates(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public void CreateAccountState(AccountState entity)
        {
            _repository.AccountState.Create(entity);
        }

        public int GetAccountStatesCount()
        {
            return _repository.AccountState.Count();
        }

        public async Task DeleteAccountState(int id)
        {
            AccountState entity = await FindAccountStateById(id, trackChanges: false);

            _repository.AccountState.Delete(entity);
        }

        #endregion
    }
}
