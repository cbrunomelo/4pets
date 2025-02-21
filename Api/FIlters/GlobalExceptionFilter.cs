using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Api.FIlters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
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
        }
    }
}
