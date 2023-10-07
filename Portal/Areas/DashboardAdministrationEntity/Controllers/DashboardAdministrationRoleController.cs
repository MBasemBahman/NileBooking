using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.DashboardAdministrationModels;
using Entities.DBModels.DashboardAdministrationModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Portal.Areas.DashboardAdministrationEntity.Models;

namespace Portal.Areas.DashboardAdministrationEntity.Controllers
{
    [Area("DashboardAdministrationEntity")]
    [Authorize(DashboardViewEnum.DashboardAdministrationRole, DashboardAccessLevelEnum.Viewer)]
    public class DashboardAdministrationRoleController : ExtendControllerBase
    {
        public DashboardAdministrationRoleController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {
        }

        public IActionResult Index()
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            var model = _mapper.Map<List<DashboardAdministrationRoleDto>>
              (_unitOfWork.DashboardAdministration.GetRoles(
                  new DashboardAdministrationRoleRequestParameters(), otherLang));

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            return View(model);

        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            var model = _mapper.Map<List<DashboardAdministrationRoleDto>>
                (_unitOfWork.DashboardAdministration.GetRoles(
                    new DashboardAdministrationRoleRequestParameters(), otherLang));

            return Json(model);
        }


        [Authorize(DashboardViewEnum.DashboardAdministrationRole, DashboardAccessLevelEnum.DataControl)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            DashboardAdministrationRoleCreateOrEditModel model = _unitOfWork.DashboardAdministration.GetRoleCreateOrEditModel(id);

            SetViewData();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.DashboardAdministrationRole, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, DashboardAdministrationRoleCreateOrEditModel model)
        {
            List<ModelError> errors = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    errors = ModelState
                            .Select(a => a.Value)
                            .SelectMany(a => a.Errors)
                            .ToList();

                    throw new Exception("");
                }

                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

                if (id == 0)
                {
                    _unitOfWork.DashboardAdministration.CreateDashboardAdministrationRole(model);
                }
                else
                {
                   await _unitOfWork.DashboardAdministration.UpdateDashboardAdministrationRole(id, model);
                }

                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                errors.Add(new ModelError(ex, GetExceptionMsg(ex.Message)));
            }

            return BadRequest(errors);
        }



		[HttpPost]
		[Authorize(DashboardViewEnum.DashboardAdministrationRole, DashboardAccessLevelEnum.FullAccess)]
		public async Task<IActionResult> Delete(int id)
		{
			List<ModelError> errors = new();

			try
			{
				await _unitOfWork.DashboardAdministration.DeleteRole(id);
				await _unitOfWork.Save();

				return Ok();
			}
			catch (Exception ex)
			{
				errors.Add(new ModelError(ex, GetExceptionMsg(ex.Message)));
			}

			return BadRequest(errors);
		}

        [HttpGet]
        public IActionResult GetRolesAdminCount(int id)
        {
            var result = _unitOfWork.DashboardAdministration.GetRolebyId(id, language: null).AdministratorsCount;

            return Json(result);
        }
        //helper methods
        public void SetViewData()
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            ViewData["Views"] = _unitOfWork.DashboardAdministration.GetViewsLookUp(new DashboardViewParameters());
        }
    }
}
