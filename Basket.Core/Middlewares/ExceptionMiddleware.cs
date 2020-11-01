using Basket.Core.Exceptions;
using Basket.Core.Extensions;
using Basket.Core.Logs;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly ILogger Logger = Log.ForContext<ExceptionMiddleware>();

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await NotFoundException(context, ex, ex.Message);
            }
            catch (Exception ex)
            {
                await InternalServerError(context, ex, ex.Message);
            }
            
        }

        private static async Task InternalServerError(HttpContext context,
            Exception exception,
            string data,
            string contentType = "text/plain")
        {
            await Task.Run(() =>
            {
                var request = context.Request;

                var logModel = new LoggerModel
                {
                    RequestHost = request.Host.Host,
                    RequestProtocol = request.Protocol,
                    RequestMethod = request.Method,
                    RequestPath = request.Path,
                    RequestHeaders = request.Headers.ToDictionary(x => x.Key, x => (object)x.Value.ToString()),
                    RequestBody = string.Empty,
                    Exception = exception,
                    Data = data
                };
                Logger.HandleLogging(logModel).Error(LogTemplates.Error);
            });

            context.Response.ContentType = contentType;
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*"); 
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(exception.Message, Encoding.UTF8);
        }

        private static async Task NotFoundException(HttpContext context,
           Exception exception,
           string data,
           string contentType = "text/plain")
        {
            await Task.Run(() =>
            {
                var request = context.Request;

                var logModel = new LoggerModel
                {
                    RequestHost = request.Host.Host,
                    RequestProtocol = request.Protocol,
                    RequestMethod = request.Method,
                    RequestPath = request.Path,
                    RequestHeaders = request.Headers.ToDictionary(x => x.Key, x => (object)x.Value.ToString()),
                    RequestBody = string.Empty,
                    Exception = exception,
                    Data = data
                };
                Logger.HandleLogging(logModel).Error(LogTemplates.Error);
            });

            context.Response.ContentType = contentType;
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync(exception.Message, Encoding.UTF8);
        }
    }
}
