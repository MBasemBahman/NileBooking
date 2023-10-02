using Entities.CoreServicesModels.HotelRoomModels;
using Entities.DBModels.HotelRoomModels;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.HotelRoomEntity.Models;

namespace Portal.Areas.HotelRoomEntity.Controllers
{
    [Area("HotelRoomEntity")]
    [Authorize(DashboardViewEnum.RoomType, DashboardAccessLevelEnum.Viewer)]
    public class RoomTypeController : ExtendControllerBase
    {
        public RoomTypeController(IMapper mapper,
        AuthenticationManager authManager, UnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        LocalizationManager localizer) : base(mapper, authManager, unitOfWork, environment, localizer)
        {

        }
        public IActionResult Index()
        {
            RoomTypeFilter filter = new();

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] RoomTypeFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            RoomTypeParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<RoomTypeModel> data = await _unitOfWork.HotelRoom.GetRoomTypesPaged(parameters, otherLang);

            List<RoomTypeDto> resultDto = _mapper.Map<List<RoomTypeDto>>(data);

            DataTable<RoomTypeDto> dataTableManager = new();

            DataTableResult<RoomTypeDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.HotelRoom.GetRoomTypesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            RoomTypeDto data = _mapper.Map<RoomTypeDto>(_unitOfWork.HotelRoom.GetRoomTypeById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.RoomType, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            RoomTypeCreateOrEditModel model = new();

            if (id > 0)
            {
                RoomType dataDB = await _unitOfWork.HotelRoom.FindRoomTypeById(id, trackChanges: false);
                model = _mapper.Map<RoomTypeCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.RoomTypeLangs ??= new List<RoomTypeLangModel>();

                    if (model.RoomTypeLangs.All(a => a.Language != language))
                    {
                        model.RoomTypeLangs.Add(new RoomTypeLangModel
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
        [Authorize(DashboardViewEnum.RoomType, DashboardAccessLevelEnum.DataControl)]
        public async Task<IActionResult> CreateOrEdit(int id, RoomTypeCreateOrEditModel model)
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
                RoomType dataDB = new();

                if (id == 0)
                {
                    dataDB = _mapper.Map<RoomType>(model);
                    _unitOfWork.HotelRoom.CreateRoomType(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.HotelRoom.FindRoomTypeById(id, trackChanges: true);

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
        [Authorize(DashboardViewEnum.RoomType, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.HotelRoom.DeleteRoomType(id);
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
