using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.HotelEntity.Models;

namespace Portal.Areas.HotelEntity.Controllers
{
    [Area("HotelEntity")]
    [Authorize(DashboardViewEnum.HotelType, DashboardAccessLevelEnum.Viewer)]
    public class HotelTypeController : ExtendControllerBase
    {
        public HotelTypeController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }
        public IActionResult Index()
        {
            HotelTypeFilter filter = new();

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] HotelTypeFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelTypeParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<HotelTypeModel> data = await _unitOfWork.Hotel.GetHotelTypesPaged(parameters, otherLang);

            List<HotelTypeDto> resultDto = _mapper.Map<List<HotelTypeDto>>(data);

            DataTable<HotelTypeDto> dataTableManager = new();

            DataTableResult<HotelTypeDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Hotel.GetHotelTypesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelTypeDto data = _mapper.Map<HotelTypeDto>(_unitOfWork.Hotel.GetHotelTypeById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.HotelType, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            HotelTypeCreateOrEditModel model = new();

            if (id > 0)
            {
                HotelType dataDB = await _unitOfWork.Hotel.FindHotelTypeById(id, trackChanges: false);
                model = _mapper.Map<HotelTypeCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.HotelTypeLangs ??= new List<HotelTypeLangModel>();

                    if (model.HotelTypeLangs.All(a => a.Language != language))
                    {
                        model.HotelTypeLangs.Add(new HotelTypeLangModel
                        {
                            Language = language
                        });
                    }
                }

                #endregion
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.HotelType, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, HotelTypeCreateOrEditModel model)
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
                HotelType dataDB = new();

                if (id == 0)
                {
                    dataDB = _mapper.Map<HotelType>(model);
                    _unitOfWork.Hotel.CreateHotelType(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Hotel.FindHotelTypeById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);
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
        [Authorize(DashboardViewEnum.HotelType, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.Hotel.DeleteHotelType(id);
                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                errors.Add(new ModelError(ex, GetExceptionMsg(ex.Message)));
            }

            return BadRequest(errors);
        }
    }
}
