using CVGenerator.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace CVGenerator.Web.Middlewares
{
    /// <summary>
    /// Глобальный обработчик ошибок.
    /// </summary>
    public class GeneratorExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GeneratorExceptionHandlerMiddleware> _logger;

        public GeneratorExceptionHandlerMiddleware(RequestDelegate next, ILogger<GeneratorExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        /// <summary>
        /// Реализует логику обработки ошибок.
        /// </summary>
        /// <param name="context">HTTP-данные запроса.</param>
        /// <param name="exception">Ошибка.</param>
        /// <returns>HTTP-данные c информацией об ошибке для клиента в виде JSON.</returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception.Message);
            var code = HttpStatusCode.InternalServerError;
            var result = ": " + exception.Message;

            switch (exception)
            {
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case ForbiddenException:
                    code = HttpStatusCode.Forbidden;
                    break;
                case AuthenticationException:
                    code = HttpStatusCode.Unauthorized;
                    result = ": Неверный логин/пароль";
                    break;
                default:
                    result = ": Внутренняя ошибка сервера";
                    break;
            }

            result = string.Concat((int)code, result);
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
