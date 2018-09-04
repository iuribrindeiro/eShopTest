using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using eShopTest.Domain.SeedWork.Exception;
using eShopTest.Presentation.ObjectResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace eShopTest.Presentation.Filters
{
    public class ErrorFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            var exceptionInstance = context.Exception;
            var message = exceptionInstance is AbstractException ? context.Exception.Message : AbstractException.DefaultMessage;
            response.ContentType = "application/json";

            if (exceptionInstance is EntityNotFoundException)
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.WriteAsync(JsonConvert.SerializeObject(new DefaultResponse() { Message = message }));
                return;
            }

            response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.WriteAsync(JsonConvert.SerializeObject(new DefaultResponse() { Message = message }));
        }
    }
}
