using API.Controllers;
using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.UserModels;

namespace API.Areas.UserArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Authentication")]
    [ApiExplorerSettings(GroupName = "Authentication")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    public class DeviceController : ExtendControllerBase
    {
        public DeviceController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {
        }

        [HttpPost]
        [Route(nameof(CreateUserDevice))]
        public async Task<bool> CreateUserDevice(
            [FromBody] DeviceCreateModel model)
        {
            _ = (bool)Request.HttpContext.Items[ApiConstants.Language];
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            User user = await _unitOfWork.User.FindById(auth.Id, trackChanges: true);
            user.Culture = (string)Request.HttpContext.Items[HeadersConstants.Culture];

            Device device = _mapper.Map<Device>(model);
            device.Fk_User = auth.Id;

            _unitOfWork.User.CreateDevice(device);
            await _unitOfWork.Save();

            return true;
        }

        [HttpDelete]
        [Route(nameof(DeleteUserDevices))]
        public async Task<bool> DeleteUserDevices()
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            IEnumerable<Device> devices = await _unitOfWork.User.FindDevicesByUserId(auth.Id, trackChanges: true);

            foreach (Device device in devices)
            {
                _unitOfWork.User.DeleteDevice(device);
            }

            await _unitOfWork.Save();

            return true;
        }
    }
}
