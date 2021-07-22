using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SampleProject.Business.Exceptions;
using System;
using System.Net;

namespace EF_CodefFirst_SampleProject.Mvc
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;
        private readonly IWebHostEnvironment _env;

        public HttpGlobalExceptionFilter(ILogger<HttpGlobalExceptionFilter> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            this._env = env;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);

            if (context.Exception is IS27Exception ex)
            {
                HandleDocumentedException(ex, context);
            }
            else
            {
                HandleUndocumentedException(context);
            }
            context.ExceptionHandled = true;
        }

        private void HandleUndocumentedException(ExceptionContext context)
        {
            context.Result = new ObjectResult(
                context.Exception.Message
            );

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        private void HandleDocumentedException(IS27Exception er, ExceptionContext context)
        {
            var problemDetails = new ValidationProblemDetails
            {
                Instance = context.HttpContext.Request.Path,
                Detail = "Please refer to the errors property for additional details."
            };

            if (er is FieldValidationException fieldValidationError)
            {
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Errors.Add(fieldValidationError.FieldName, new[] { fieldValidationError.Message });
            }
            else if (er is FieldNotFoundException fieldNotFoundException)
            {
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Errors.Add(fieldNotFoundException.FieldName, new[] { fieldNotFoundException.Message });
            }
            else if (er is UnauthorizedException unauthorizedException)
            {
                problemDetails.Status = StatusCodes.Status403Forbidden;
                problemDetails.Errors.Add("unauthorized", new[] { unauthorizedException.Message });
            }

            else if (er is DomainErrorException domainErrorException)
            {
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Errors.Add("error", new[] { domainErrorException.Message });
            }
            else
            {
                var error = $"Please register {er.GetType()} in {nameof(HttpGlobalExceptionFilter)}.{nameof(HandleDocumentedException)}";
                _logger.LogError(context.Exception, context.Exception.Message);

                if (_env.IsDevelopment())
                {
                    throw new NotImplementedException(error);
                }
                else
                {
                    problemDetails.Status = StatusCodes.Status500InternalServerError;
                    problemDetails.Errors.Add("error", new[] { "Internal Server Error" });
                }
            }


            context.Result = new BadRequestObjectResult(problemDetails);
            context.HttpContext.Response.StatusCode = (int)problemDetails.Status;
        }
    }
}
