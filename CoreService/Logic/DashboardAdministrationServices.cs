using Entities.CoreServicesModels.DashboardAdministrationModels;
using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.DashboardAdministrationModels;

namespace CoreService.Logic
{
    public class DashboardAdministrationServices
    {
        private readonly RepositoryManager _repository;

        public DashboardAdministrationServices(RepositoryManager repository)
        {
            _repository = repository;
        }

        #region  Dashboard View Services
        public IQueryable<DashboardViewModel> GetViews(DashboardViewParameters parameters)
        {
            return _repository.DashboardView
                       .FindAll(parameters, trackChanges: false)
                       .Select(a => new DashboardViewModel
                       {
                           Name = a.Name,
                           Id = a.Id,
                           CreatedAt = a.CreatedAt,
                           ViewPath = a.ViewPath,
                           PremissionsCount = a.Premissions.Count
                       })
                       .Search(parameters.SearchColumns, parameters.SearchTerm)
                       .Sort(parameters.OrderBy);
        }


        public async Task<PagedList<DashboardViewModel>> GetViewsPaged(
                  DashboardViewParameters parameters)
        {
            return await PagedList<DashboardViewModel>.ToPagedList(GetViews(parameters), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<DashboardView> FindViewById(int id, bool trackChanges)
        {
            return await _repository.DashboardView.FindById(id, trackChanges);
        }

        public DashboardViewModel GetViewbyId(int id)
        {
            return GetViews(new DashboardViewParameters { Id = id }).SingleOrDefault();
        }

        public List<int> GetViewsByRoleId(int fk_role)
        {
            return _repository.DashboardView
                       .FindAll(new DashboardViewParameters { Fk_Role = fk_role }, trackChanges: false)
                       .Select(a => a.Id)
                       .ToList();
        }

        public void CreateView(DashboardView dashboardView)
        {
            _repository.DashboardView.Create(dashboardView);
        }

        public async Task DeleteView(int id)
        {
            DashboardView dashboardView = await FindViewById(id, trackChanges: false);
            _repository.DashboardView.Delete(dashboardView);
        }

        public Dictionary<string, string> GetViewsLookUp(DashboardViewParameters parameters)
        {
            return GetViews(parameters).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public int GetViewsCount()
        {
            return _repository.DashboardView.Count();
        }
        #endregion

        #region Dashboard Access Level Services
        public IQueryable<DashboardAccessLevelModel> GetAccessLevels(DashboardAccessLevelParameters parameters)
        {
            return _repository.DashboardAccessLevel
                       .FindAll(parameters, trackChanges: false)
                       .Select(a => new DashboardAccessLevelModel
                       {
                           Name = a.Name,
                           Id = a.Id,
                           CreatedAt = a.CreatedAt,
                           CreateAccess = a.CreateAccess,
                           EditAccess = a.EditAccess,
                           DeleteAccess = a.DeleteAccess,
                           ViewAccess = a.ViewAccess,
                           PremissionsCount = a.Premissions.Count,
                       })
                       .Search(parameters.SearchColumns, parameters.SearchTerm)
                       .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<DashboardAccessLevelModel>> GetAccessLevelsPaged(
                  DashboardAccessLevelParameters parameters)
        {
            return await PagedList<DashboardAccessLevelModel>.ToPagedList(GetAccessLevels(parameters), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<DashboardAccessLevel> FindAccessLevelById(int id, bool trackChanges)
        {
            return await _repository.DashboardAccessLevel.FindById(id, trackChanges);
        }

        public DashboardAccessLevelModel GetAccessLevelbyId(int id)
        {
            return GetAccessLevels(new DashboardAccessLevelParameters { Id = id }).SingleOrDefault();
        }

        public DashboardAccessLevelModel GetAccessLevelByPremission(DashboardAccessLevelParameters parameters)
        {
            return GetAccessLevels(parameters).FirstOrDefault();
        }

        public void CreateAccessLevel(DashboardAccessLevel dashboardAccessLevel)
        {
            _repository.DashboardAccessLevel.Create(dashboardAccessLevel);
        }

        public async Task DeleteAccessLevel(int id)
        {
            DashboardAccessLevel dashboardAccessLevel = await FindAccessLevelById(id, trackChanges: false);
            _repository.DashboardAccessLevel.Delete(dashboardAccessLevel);
        }

        public Dictionary<string, string> GetAccessLevelsLookUp(DashboardAccessLevelParameters parameters)
        {
            return GetAccessLevels(parameters).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public int GetAccessLevelsCount()
        {
            return _repository.DashboardAccessLevel.Count();
        }
        #endregion

        #region Dashboard Administration Role Services
        public IQueryable<DashboardAdministrationRoleModel> GetRoles(DashboardAdministrationRoleRequestParameters parameters,
               LanguageEnum? language)
        {
            return _repository.DashboardAdministrationRole
                       .FindAll(parameters, trackChanges: false)
                       .Select(a => new DashboardAdministrationRoleModel
                       {
                           Name = language != null ? a.DashboardAdministrationRoleLangs
                               .Where(b => b.Language == language)
                               .Select(b => b.Name).FirstOrDefault() : a.Name,
                           Id = a.Id,
                           CreatedAt = a.CreatedAt,
                           PremissionsCount = a.Premissions.Count,
                           AdministratorsCount = a.Administrators.Count,
                          
                       })
                       .Search(parameters.SearchColumns, parameters.SearchTerm)
                       .Sort(parameters.OrderBy);
        }


        public async Task<PagedList<DashboardAdministrationRoleModel>> GetRolesPaged(
                  DashboardAdministrationRoleRequestParameters parameters,
                  LanguageEnum? language)
        {
            return await PagedList<DashboardAdministrationRoleModel>.ToPagedList(GetRoles(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<DashboardAdministrationRole> FindRoleById(int id, bool trackChanges)
        {
            return await _repository.DashboardAdministrationRole.FindById(id, trackChanges);
        }

        public DashboardAdministrationRoleModel GetRolebyId(int id, LanguageEnum? language)
        {
            return GetRoles(new DashboardAdministrationRoleRequestParameters { Id = id }, language).SingleOrDefault();
        }

        public void CreateRole(DashboardAdministrationRole dashboardAdministrationRole)
        {
            _repository.DashboardAdministrationRole.Create(dashboardAdministrationRole);
        }

      
        public async Task DeleteRole(int id)
        {
            DashboardAdministrationRole dashboardAdministrationRole = await FindRoleById(id, trackChanges: false);
            _repository.DashboardAdministrationRole.Delete(dashboardAdministrationRole);
        }

        public Dictionary<string, string> GetRolesLookUp(DashboardAdministrationRoleRequestParameters parameters, LanguageEnum? language)
        {
            return GetRoles(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public int GetRolesCount()
        {
            return _repository.DashboardAdministrationRole.Count();
        }
        #endregion

        #region Dashboard Administrator Services
        public IQueryable<DashboardAdministratorModel> GetAdministrators(DashboardAdministratorParameters parameters,
               LanguageEnum? language)
        {
            return _repository.DashboardAdministrator
                       .FindAll(parameters, trackChanges: false)
                       .Select(a => new DashboardAdministratorModel
                       {
                           Fk_User = a.Fk_User,
                           Fk_DashboardAdministrationRole = a.Fk_DashboardAdministrationRole,
                           Id = a.Id,
                           CreatedAt = a.CreatedAt,
                           CreatedBy = a.CreatedBy,
                           LastModifiedAt = a.LastModifiedAt,
                           LastModifiedBy = a.LastModifiedBy,
                           IsActive = a.IsActive,
                           User = new UserModel
                           {
                               FirstName = a.User.FirstName,
                               LastName = a.User.LastName,
                               FullName = a.User.FullName,
                               UserName = a.User.UserName,
                               PhoneNumber = a.User.PhoneNumber,
                               EmailAddress = a.User.EmailAddress,
                           },
                           DashboardAdministrationRole = new DashboardAdministrationRoleModel
                           {
                               Name = language != null ? a.DashboardAdministrationRole.DashboardAdministrationRoleLangs
                               .Where(b => b.Language == language)
                               .Select(b => b.Name).FirstOrDefault() : a.DashboardAdministrationRole.Name,
                           },
                           JobTitle = a.JobTitle,
                       })
                       .Search(parameters.SearchColumns, parameters.SearchTerm)
                       .Sort(parameters.OrderBy);
        }


        public async Task<PagedList<DashboardAdministratorModel>> GetAdministratorsPaged(
                  DashboardAdministratorParameters parameters,
                  LanguageEnum? language)
        {
            return await PagedList<DashboardAdministratorModel>.ToPagedList(GetAdministrators(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<DashboardAdministrator> FindAdministratorById(int id, bool trackChanges)
        {
            return await _repository.DashboardAdministrator.FindById(id, trackChanges);
        }

        public async Task<DashboardAdministrator> FindByUserId(int id, bool trackChanges)
        {
            return await _repository.DashboardAdministrator.FindByUserId(id, trackChanges);
        }

        public DashboardAdministratorModel GetAdministratorbyId(int id, LanguageEnum? language)
        {
            return GetAdministrators(new DashboardAdministratorParameters { Id = id, GetDevelopers = true }, language).SingleOrDefault();
        }

        public void CreateAdministrator(DashboardAdministrator dashboardAdministrator)
        {
            if (dashboardAdministrator.User != null)
            {
                dashboardAdministrator.User.Password = BC.HashPassword(dashboardAdministrator.User.Password);
            }
            _repository.DashboardAdministrator.Create(dashboardAdministrator);
        }

        public async Task DeleteAdministrator(int id)
        {
            DashboardAdministrator dashboardAdministrator = await FindAdministratorById(id, trackChanges: false);
            _repository.DashboardAdministrator.Delete(dashboardAdministrator);
        }

        public int GetAdministratorsCount()
        {
            return _repository.DashboardAdministrator.Count();
        }
        #endregion

        #region Administration Role Premission Services
        public IQueryable<AdministrationRolePremissionModel> GetPremissions(AdministrationRolePremissionParameters parameters,
               LanguageEnum? language)
        {
            return _repository.AdministrationRolePremission
                       .FindAll(parameters, trackChanges: false)
                       .Select(a => new AdministrationRolePremissionModel
                       {
                           Fk_DashboardAccessLevel = a.Fk_DashboardAccessLevel,
                           Fk_DashboardAdministrationRole = a.Fk_DashboardAdministrationRole,
                           Fk_DashboardView = a.Fk_DashboardView,
                           Id = a.Id,
                           CreatedAt = a.CreatedAt,
                           DashboardAdministrationRole = new DashboardAdministrationRoleModel
                           {
                               Name = language != null ? a.DashboardAdministrationRole.DashboardAdministrationRoleLangs
                               .Where(b => b.Language == language)
                               .Select(b => b.Name).FirstOrDefault() : a.DashboardAdministrationRole.Name,
                           },
                           DashboardAccessLevel = new DashboardAccessLevelModel
                           {
                               Name = a.DashboardAccessLevel.Name
                           },
                           DashboardView = new DashboardViewModel
                           {
                               Name = a.DashboardView.Name
                           },
                       })
                       .Search(parameters.SearchColumns, parameters.SearchTerm)
                       .Sort(parameters.OrderBy);
        }



        #endregion

        public DashboardAdministrationRoleCreateOrEditModel GetRoleCreateOrEditModel(int fk_Role)
        {
            DashboardAdministrationRoleCreateOrEditModel model = new DashboardAdministrationRoleCreateOrEditModel()
            {
                RolePremissions = new List<AdministrationRolePremissionCreateOrEditModel>(),
            };
            if(fk_Role > 0)
            {
                var roleDB = FindRoleById(fk_Role, trackChanges: false).Result;



                model.Name = roleDB.Name;

                if (roleDB.DashboardAdministrationRoleLangs != null && roleDB.DashboardAdministrationRoleLangs.Any())
                {
                    model.DashboardAdministrationRoleLangs = new List<DashboardAdministrationRoleLangModel>();

                    foreach(var lang in roleDB.DashboardAdministrationRoleLangs)
                    {
                        model.DashboardAdministrationRoleLangs.Add(new DashboardAdministrationRoleLangModel
                        {
                            Name = lang.Name,
                            Language = lang.Language
                        });
                    }
                }

            }
            foreach (DashboardAccessLevelEnum value in Enum.GetValues(typeof(DashboardAccessLevelEnum)))
            {
                model.RolePremissions.Add(new AdministrationRolePremissionCreateOrEditModel
                {
                    Fk_DashboardAccessLevel = (int)value,
                    Fk_DashboardView = fk_Role > 0
					? GetPremissions(new AdministrationRolePremissionParameters
					{
						Fk_DashboardAdministrationRole = fk_Role,
						Fk_DashboardAccessLevel = (int)value
					}, language: null).Select(a => a.Fk_DashboardView).ToList()
					: new List<int>()
				});
            
            }

            return model;
        }

        public void CreateDashboardAdministrationRole(DashboardAdministrationRoleCreateOrEditModel model)
        {
            DashboardAdministrationRole roleDB = new DashboardAdministrationRole()
            {
                Name = model.Name,
            };

            if(model.DashboardAdministrationRoleLangs!=null&& model.DashboardAdministrationRoleLangs.Any())
            {
                roleDB.DashboardAdministrationRoleLangs = new List<DashboardAdministrationRoleLang>();

                foreach(var lang in model.DashboardAdministrationRoleLangs)
                {
                    roleDB.DashboardAdministrationRoleLangs.Add(new DashboardAdministrationRoleLang
                    {
                        Name = lang.Name,
                        Language = lang.Language,
                    });
                }
            }

            if(model.RolePremissions != null && model.RolePremissions.Any())
            {
                roleDB.Premissions = new List<AdministrationRolePremission>();

                foreach(var permission in model.RolePremissions)
                {
                 if(permission.Fk_DashboardView != null && permission.Fk_DashboardView.Any())
                    {
						foreach (var view in permission.Fk_DashboardView)
						{
							roleDB.Premissions.Add(new AdministrationRolePremission
							{
								Fk_DashboardAccessLevel = permission.Fk_DashboardAccessLevel,
								Fk_DashboardView = view,
							});
						}
					}
                }
            }

            CreateRole(roleDB);
        }

        public async Task UpdateDashboardAdministrationRole(int fk_Role,DashboardAdministrationRoleCreateOrEditModel model)
        {
            DashboardAdministrationRole roleDB = await FindRoleById(fk_Role, trackChanges: true);

            var oldPermissions = GetPremissions(new AdministrationRolePremissionParameters
            {
                Fk_DashboardAdministrationRole = fk_Role
            }, language: null);

            roleDB.Name = model.Name;



            foreach (DashboardAccessLevelEnum value in Enum.GetValues(typeof(DashboardAccessLevelEnum)))
            {
                var oldViewsAccess = oldPermissions.Where(a => a.Fk_DashboardAccessLevel == (int)value)
                                               .Select(a => a.Fk_DashboardView).ToList();

                var newViewsAccess = model.RolePremissions.Where(a => a.Fk_DashboardAccessLevel == (int)value)
                    .FirstOrDefault().Fk_DashboardView;

                newViewsAccess = newViewsAccess ?? new List<int>();

                List<int> deletedViewsAccess = oldViewsAccess.Except(newViewsAccess).ToList();

                List<int> addedViewsAccess = newViewsAccess.Except(oldViewsAccess).ToList();

                DeleteRolePermissions(fk_Role, (int)value, deletedViewsAccess);

                AddRolePermissions(fk_Role,(int)value, addedViewsAccess);
            }

        }
        public void DeleteRolePermissions(int fk_Role,int fk_Access,List<int> fk_Views)
        {
            if(fk_Views != null && fk_Views.Any())
            {
                foreach (int fk_view in fk_Views)
                {
                    AdministrationRolePremission premission =
                        _repository.AdministrationRolePremission.FindAll(new AdministrationRolePremissionParameters
                        {
                            Fk_DashboardAccessLevel = fk_Access,
                            Fk_DashboardAdministrationRole = fk_Role,
                            Fk_DashboardView = fk_view
                        }, trackChanges: false).SingleOrDefault();

                    _repository.AdministrationRolePremission.Delete(premission);
                }
            }
        }

        private void AddRolePermissions(int fk_role, int fk_accesslevel, List<int> fk_views)
        {
            foreach (int fk_view in fk_views)
            {
                AdministrationRolePremission premission = new()
                {
                    Fk_DashboardAccessLevel = fk_accesslevel,
                    Fk_DashboardAdministrationRole = fk_role,
                    Fk_DashboardView = fk_view
                };

                _repository.AdministrationRolePremission.Create(premission);
            }
        }

    }
}
