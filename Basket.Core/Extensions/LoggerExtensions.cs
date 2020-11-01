using Basket.Core.Logs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basket.Core.Extensions
{
    public static class LoggerExtensions
    {
        public static ILogger HandleLogging(this ILogger logger, LoggerModel loggerModel)
        {
            if (loggerModel == null)
            {
                return logger;
            }

            logger = logger
                .ForContext(nameof(loggerModel.RequestHost), loggerModel.RequestHost)
                .ForContext(nameof(loggerModel.RequestProtocol), loggerModel.RequestProtocol)
                .ForContext(nameof(loggerModel.RequestMethod), loggerModel.RequestMethod)
                .ForContext(nameof(loggerModel.ResponseStatusCode), loggerModel.ResponseStatusCode)
                .ForContext(nameof(loggerModel.RequestPath), loggerModel.RequestPath)
                .ForContext(nameof(loggerModel.RequestPathAndQuery), loggerModel.RequestPathAndQuery);

            if (loggerModel.RequestHeaders != null && loggerModel.RequestHeaders.Any())
                logger = logger.ForContext(nameof(loggerModel.RequestHeaders), loggerModel.RequestHeaders, true);

            if (loggerModel.ElapsedMilliseconds != null)
                logger = logger.ForContext(nameof(loggerModel.ElapsedMilliseconds), loggerModel.ElapsedMilliseconds);

            if (!string.IsNullOrEmpty(loggerModel.RequestBody))
                logger = logger.ForContext(nameof(loggerModel.RequestBody), loggerModel.RequestBody);

            if (loggerModel.Exception != null) logger = logger.ForContext(nameof(loggerModel.Exception), loggerModel.Exception, true);

            if (!string.IsNullOrEmpty(loggerModel.Data))
                logger = logger.ForContext(nameof(loggerModel.Data), loggerModel.Data);

            return logger;
        }

    }
}
