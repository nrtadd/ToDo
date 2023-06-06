using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using ToDoTemplate.Application.Common.Exceptions;

namespace WebApi.Middleware.Exceptions
{
    public class ExceptionsHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionsHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandlerExceptionAsync(context, ex);
            }
        }
        private Task HandlerExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode httpcode = HttpStatusCode.InternalServerError;
            string result = "";
            switch (exception)
            {
                case ValidationException validation:
                    httpcode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validation.Message);
                    break;
                case NotFoundException:
                    httpcode = HttpStatusCode.NotFound;
                    break;
                case IdentityExceptions identity:
                    httpcode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(identity.Message);
                    break;
                default:
                    result = JsonSerializer.Serialize(exception.Message);
                    break;

            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpcode;
            return context.Response.WriteAsync(result);
        }


    }

}

