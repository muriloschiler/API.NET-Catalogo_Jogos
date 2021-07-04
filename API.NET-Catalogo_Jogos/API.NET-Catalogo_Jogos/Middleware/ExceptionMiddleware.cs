using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(/*requisicao*/ HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch
            {
                await HandleExceptionAsync(context);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context)
        {
            // O valor desse middleware pode estar na possibilidade de se registrar logs das exceptions 
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new { Message = "Ocorreu um erro durante sua solicitação, por favor, tente novamente mais tarde" });
        }
    }
}
