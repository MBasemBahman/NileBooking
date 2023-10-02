using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.HotelRoomModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.HotelRoomEntity.Models;

namespace Portal.Areas.HotelRoomEntity.Controllers
{
    [Area("HotelRoomEntity")]
    [Authorize(DashboardViewEnum.RoomFoodType, DashboardAccessLevelEnum.Viewer)]
    public class RoomFoodTypeController : ExtendControllerBase
    {
        public RoomFoodTypeController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }
        public IActionResult Index()
        {
            RoomFoodTypeFilter filter = new();

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] RoomFoodTypeFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            RoomFoodTypeParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<RoomFoodTypeModel> data = await _unitOfWork.HotelRoom.GetRoomFoodTypesPaged(parameters, otherLang);

            List<RoomFoodTypeDto> resultDto = _mapper.Map<List<RoomFoodTypeDto>>(data);

            DataTable<RoomFoodTypeDto> dataTableManager = new();

            DataTableResult<RoomFoodTypeDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.HotelRoom.GetRoomFoodTypesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            RoomFoodTypeDto data = _mapper.Map<RoomFoodTypeDto>(_unitOfWork.HotelRoom.GetRoomFoodTypeById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.RoomFoodType, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            RoomFoodTypeCreateOrEditModel model = new();

            if (id > 0)
            {
                RoomFoodType dataDB = await _unitOfWork.HotelRoom.FindRoomFoodTypeById(id, trackChanges: false);
                model = _mapper.Map<RoomFoodTypeCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.RoomFoodTypeLangs ??= new List<RoomFoodTypeLangModel>();

                    if (model.RoomFoodTypeLangs.All(a => a.Language != language))
                    {
                        model.RoomFoodTypeLangs.Add(new RoomFoodTypeLangModel
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
        [Authorize(DashboardViewEnum.RoomFoodType, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, RoomFoodTypeCreateOrEditModel model)
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
                RoomFoodType dataDB = new();

                if (id == 0)
                {
                    dataDB = _mapper.Map<RoomFoodType>(model);
                    _unitOfWork.HotelRoom.CreateRoomFoodType(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.HotelRoom.FindRoomFoodTypeById(id, trackChanges: true);

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
        [Authorize(DashboardViewEnum.RoomFoodType, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.HotelRoom.DeleteRoomFoodType(id);
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
