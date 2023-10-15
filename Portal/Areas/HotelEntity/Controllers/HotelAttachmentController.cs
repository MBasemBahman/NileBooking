using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;
using Entities.Extensions;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal.Areas.HotelEntity.Models;

namespace Portal.Areas.HotelEntity.Controllers
{
    [Area("HotelEntity")]
    [Authorize(DashboardViewEnum.HotelAttachment, DashboardAccessLevelEnum.Viewer)]
    public class HotelAttachmentController : ExtendControllerBase
    {
        private readonly LinkGenerator _linkGenerator;
        public HotelAttachmentController(IMapper mapper,
            AuthenticationManager authManager, UnitOfWork unitOfWork,
            IWebHostEnvironment environment,
            LocalizationManager localizer,
            LinkGenerator linkGenerator) : base(mapper, authManager, unitOfWork, environment, localizer)
        {
            _linkGenerator = linkGenerator;
        }

        public IActionResult Index(int id, int Fk_Hotel)
        {

            HotelAttachmentFilter filter = new()
            {
                Id = id,
                Fk_Hotel = Fk_Hotel,
            };
            
            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] HotelAttachmentFilter dtParameters)
        {
            HotelAttachmentParameters parameters = new()
            {
                SearchColumns = "Id,FileName"
            };

            _ = _mapper.Map(dtParameters, parameters);

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            PagedList<HotelAttachmentModel> data = await _unitOfWork.Hotel.GetHotelAttachmentsPaged(parameters, language);

            List<HotelAttachmentDto> resultDto = _mapper.Map<List<HotelAttachmentDto>>(data);

            DataTable<HotelAttachmentDto> dataTableManager = new();

            DataTableResult<HotelAttachmentDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Hotel.GetHotelAttachmentsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public ActionResult<List<HotelModel>> LoadHotelAttachment(int fk_Hotel)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            return Ok(_unitOfWork.Hotel.GetHotelAttachments(new HotelAttachmentParameters
            {
                Fk_Hotel = fk_Hotel
            }, language).ToList());
        }
        
        public IActionResult Details(int id)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelAttachmentDto data = _mapper.Map<HotelAttachmentDto>(_unitOfWork.Hotel
                .GetHotelAttachmentById(id, language));

            return View(data);
        }

        [HttpPost]
        [Authorize(DashboardViewEnum.HotelAttachment, DashboardAccessLevelEnum.DataControl)]
        [RequestSizeLimit(2048000000)]
        public async Task<IActionResult> Upload(int fk_Hotel)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            IFormFile file = Request.Form.Files["file"];
            if (file != null)
            {
                HotelAttachment attachment = await _unitOfWork.Hotel.UploadHotelAttachment(_environment.WebRootPath, file);
                attachment.StorageUrl = _linkGenerator.GetUriByAction(HttpContext).GetBaseUri(HttpContext.Request.RouteValues["area"].ToString());
                attachment.Fk_Hotel = fk_Hotel;
                attachment.CreatedBy = auth.UserName;
                
                _unitOfWork.Hotel.CreateHotelAttachment(attachment);
                await _unitOfWork.Save();
            }
            
            return Ok();
        }

        [HttpPost]
        [Authorize(DashboardViewEnum.HotelAttachment, DashboardAccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            List<ModelError> errors = new();

            try
            {
                await _unitOfWork.Hotel.DeleteHotelAttachment(id);
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
