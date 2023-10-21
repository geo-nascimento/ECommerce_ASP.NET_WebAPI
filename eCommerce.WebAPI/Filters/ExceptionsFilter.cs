using System.Net;
using eCommerce.Communication.Response;
using eCommerce.Exceptions;
using eCommerce.Exceptions.BabeExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eCommerce.WebAPI.Filters;

public class ExceptionsFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is eCommerceException)
        {
            CommerceExceptionsHandler(context);
        }
        else
        {
            ThrowUnknowException(context);
        }
    }

    private void CommerceExceptionsHandler(ExceptionContext context)
    {
        if (context.Exception is UserRegisterValidationError)
        {
            ValidationErrorExceptionHandler(context);
        }
    }

    private void ValidationErrorExceptionHandler(ExceptionContext context)
    {
        var error = context.Exception as UserRegisterValidationError;
        context.Result = new ObjectResult(new UserRegistrationErrorResponse(error.ErroMessages));
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }

    private void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new UserRegistrationErrorResponse(ResourcesErrosMessages.ERRRO_DESCONHECIDO));
    }
}