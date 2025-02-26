using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Api.FIlters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var statusCode = context.Exception switch
            {
                ArgumentException => HttpStatusCode.BadRequest,
                UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                _ => HttpStatusCode.InternalServerError
            };

            var msg = context.Exception switch
            {
                ArgumentException => "Argumento inválido",
                UnauthorizedAccessException => "Acesso não autorizado",
                _ => "Erro interno no servidor"
            };

            context.HttpContext.Response.StatusCode = (int)statusCode;

            context.ExceptionHandled = true;

            context.Result = new ObjectResult(
                    new ResultService<Object>(false, "Falha na requisição", msg)
                );

            var eventID = new EventId(context.Exception.HResult, context.Exception.GetType().Name);

            _logger.LogError(eventID, context.Exception, context.Exception.Message);


        }
    }
}
