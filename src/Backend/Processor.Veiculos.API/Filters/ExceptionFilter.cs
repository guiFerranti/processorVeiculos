using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Processor.Veiculos.Communication.Responses;
using Processor.Veiculos.Exceptions;
using Processor.Veiculos.Exceptions.ExceptionsBase;
using System;
using System.Net;

namespace Processor.Veiculos.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ProcessorVeiculosException)
        {
            HandleException(context);
        }else {
            ThrowUnknowException(context);
        }
    }


    private void HandleException(ExceptionContext context)
    {
        if (context.Exception is ErrorsOnValidationException)
        {
            var exception = context.Exception as ErrorsOnValidationException;

            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorMessages));
        } else if (context.Exception is NotFoundException)
        {
            var exception = context.Exception as ErrorsOnValidationException;

            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;
            context.Result = new ObjectResult(new ResponseErrorJson(exception.ErrorMessages));
        }
    }
    private void ThrowUnknowException(ExceptionContext context)
    {
        if (context.Exception is ErrorsOnValidationException)
        {
            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.UKNOWN_ERROR));
        }
    }
}
