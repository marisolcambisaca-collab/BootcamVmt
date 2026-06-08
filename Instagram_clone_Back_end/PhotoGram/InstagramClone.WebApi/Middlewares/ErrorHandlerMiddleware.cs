using InstagramClone.Application.Helpers;
using InstagramClone.Application.Models.Responses;
using InstagramClone.Domain.Exceptions;
using InstagramClone.Shared.Constants;

namespace InstagramClone.WebApi.Middlewares
{
    public class ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundException ex)
            {
                await context.Response.WriteAsJsonAsync(ManageException(context, ex, StatusCodes.Status404NotFound));
            }
            catch (BadRequestException ex)
            {
                await context.Response.WriteAsJsonAsync(ManageException(context, ex, StatusCodes.Status400BadRequest));
            }
            catch (UnauthorizedUserException ex)
            {
                await context.Response.WriteAsJsonAsync(ManageException(context, ex, StatusCodes.Status401Unauthorized));
            }
            catch (Exception ex)
            {
                var traceId = Guid.NewGuid();
                var message = ResponseConstants.ERROR_UNEXPECTED(traceId.ToString());

                logger.LogCritical("Se genero una excepcion no controlada, con el traceId: {traceId}. Excepcion: {Exception}", traceId, ex);

                await context.Response.WriteAsJsonAsync(ManageException(context, ex, StatusCodes.Status500InternalServerError, message));
            }
        }
        public GenericResponse<string> ManageException(HttpContext context, Exception exception, int statusCode, string? message = null)
        {
            var rsp = ResponseHelper.Create
                (data: message ?? exception.Message,
                message: message ?? exception.Message,
                errors: [message ?? exception.Message]
                );
            context.Response.StatusCode = statusCode;
            return rsp;
        }
    }
}
