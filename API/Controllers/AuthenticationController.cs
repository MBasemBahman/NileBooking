using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.UserModels;
using Entities.ServicesModels;
using Services;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Authentication")]
    [Route("v{version:apiVersion}/[controller]")]
    public class AuthenticationController : ExtendControllerBase
    {
        private readonly AuthenticationManager _authManager;
        private readonly EmailSender _emailSender;

        public AuthenticationController(
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        AuthenticationManager authManager,
        IOptions<AppSettings> appSettings,
        EmailSender emailSender) : base(mapper, unitOfWork, linkGenerator, environment, appSettings)
        {
            _authManager = authManager;
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route(nameof(Login))]
        [AllowAnonymous]
        public async Task<UserAuthenticatedDto> Login([FromBody] UserForAuthenticationWithExternalDto model)
        {
            UserAuthenticatedDto auth = await _authManager.Authenticate(model, IpAddress());

            SetToken(auth.TokenResponse);
            SetRefresh(auth.RefreshTokenResponse);

            return auth;
        }


        [HttpPost]
        [Route(nameof(RegisterUserWithAccount))]
        [AllowAnonymous]
        public async Task<UserAuthenticatedDto> RegisterUserWithAccount([FromBody] UserForRegistrationDto model)
        {
            if (model.UserName.IsExisting() && _unitOfWork.Account.GetAccounts(new AccountParameters
            {
                UserName = model.UserName
            }, LanguageEnum.en).Any())
            {
                throw new Exception("This user name already registered!");
            }

            User user = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                EmailAddress = model.EmailAddress,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,

                Account = new Account
                {

                    Fk_AccountState = (int)AccountStateEnum.Pending,
                    Fk_AccountType = (int)AccountTypeEnum.Client,
                },
                Verifications = new List<Verification>
                {
                    _unitOfWork.User.GenerateVerification(IpAddress(),_appSettings.VerificationTTL)
                },
                Culture = "en"
            };

            await _unitOfWork.User.CreateUser(user);
            await _unitOfWork.Save();
            
            await SendVerification(user.EmailAddress, user.Verifications.Single().Code);
            
            UserAuthenticatedDto auth = await _authManager.Authenticate(new UserForAuthenticationWithExternalDto
            {
                UserName = model.UserName,
                Password = model.Password,
            }, IpAddress());

            SetToken(auth.TokenResponse);
            SetRefresh(auth.RefreshTokenResponse);

            return auth;
        }

        [HttpPost]
        [Route(nameof(ResendActivateAccount))]
        public async Task<bool> ResendActivateAccount()
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            User user = await _unitOfWork.User.FindById(auth.Id, trackChanges: true);

            user.Verifications = new List<Verification>
            {
                _unitOfWork.User.GenerateVerification(IpAddress(),_appSettings.VerificationTTL)
            };

            await SendVerification(user.EmailAddress, user.Verifications.Single().Code);

            await _unitOfWork.Save();

            return true;
        }
        
        [HttpPut]
        [Route(nameof(ActivateAccount))]
        public async Task<bool> ActivateAccount(
            [FromBody] VerificationDto model)
        {
            try
            {
                User user = await _unitOfWork.User.Verificate(model, _appSettings.VerificationTTL);

                Account account = await _unitOfWork.Account.FindAccountByUserId(user.Id, trackChanges: true);

                account.Fk_AccountState = (int)AccountStateEnum.Active;

                await _unitOfWork.Save();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
        
        [HttpPut]
        [Route(nameof(ChangePassword))]
        public async Task<bool> ChangePassword(
           [FromBody] ChangePasswordDto model)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            await _unitOfWork.User.ChangePassword(auth.Id, model);
            await _unitOfWork.Save();

            return true;
        }

        [HttpPut]
        [Route(nameof(SetCulture))]
        public async Task<bool> SetCulture(
           [FromBody] UserForEditCultureDto model)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            User user = await _unitOfWork.User.FindById(auth.Id, trackChanges: true);

            _ = _mapper.Map(model, user);

            await _unitOfWork.Save();

            return true;
        }

        [HttpPost]
        [Route(nameof(RefreshToken))]
        [AllowAnonymous]
        public async Task<UserAuthenticatedDto> RefreshToken(
            [FromBody] UserForTokenDto model)
        {
            model.Token = System.Net.WebUtility.UrlDecode(model.Token);
            model.Token = model.Token.Replace(" ", "+");

            UserAuthenticatedDto auth = await _authManager.Authenticate(model.Token, IpAddress());

            SetToken(auth.TokenResponse);
            SetRefresh(auth.RefreshTokenResponse);

            return auth;
        }

        [HttpPost]
        [Route(nameof(RevokeToken))]
        [AllowAnonymous]
        public async Task<bool> RevokeToken(
            [FromBody] UserForTokenDto model)
        {
            _ = await _authManager.Authenticate(model.Token, IpAddress());

            await _authManager.RevokeToken(model.Token, IpAddress());

            return true;
        }
        
        private async Task SendVerification(string emailAddress, string code)
        {
            if (!string.IsNullOrWhiteSpace(emailAddress))
            {
                LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

                string template = language != null ? "email" : "email-rtl";

                string templatePath = $"/Templates/EmailTemplateV2/Verify/{template}.html";

                EmailMessage message = new(new string[] { emailAddress }, "Verification", code, _environment.WebRootPath, templatePath);
                await _emailSender.SendHtmlEmail(message);
            }
        }
    }
}
