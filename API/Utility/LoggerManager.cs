using Entities.LogFeatures;
using Newtonsoft.Json;
using Services;

namespace API.Utility
{
    public class LoggerManager
    {
        private readonly LocalizationManager _localization;

        public LoggerManager(LocalizationManager localization)
        {
            _localization = localization;
        }

        public Response LogError(HttpRequest request, Exception exception)
        {
            LogDetails logModel = new();

            if (exception != null)
            {
                logModel.ErrorMessage = _localization.Get(exception.Message ?? "");
                logModel.ExceptionMessage = exception.InnerException == null ? exception.Message : exception.InnerException.Message;

                logModel.Host = request.Host.Value;
                logModel.Path = request.Method;
                logModel.Method = request.Path.Value;
                logModel.ContentType = request.ContentType;
                logModel.QueryString = request.QueryString.Value;

                if (request.ContentLength > 0)
                {
                    if (request.HasFormContentType)
                    {
                        logModel.Body = JsonConvert.SerializeObject(request.Form);
                    }
                    else if (request.Body != null)
                    {
                        using StreamReader reader = new(request.Body);
                        _ = request.Body.Seek(0, SeekOrigin.Begin);
                        logModel.Body = reader.ReadToEnd();
                    }
                }
            }

            return new Response
            {
                ErrorMessage = logModel.ErrorMessage.Length > 150 ? _localization.Get("Something error, please try again!") : _localization.Get(logModel.ErrorMessage),
                ExceptionMessage = StringChecker.HasArabicCharacters(logModel.ExceptionMessage) ? "" : _localization.Get(logModel.ExceptionMessage)
            };
        }
    }
}