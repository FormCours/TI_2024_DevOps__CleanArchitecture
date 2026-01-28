using DemoCleanArchitecture.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DemoCleanArchitecture.Presentation.WebAPI.ExceptionHandlers
{
    public class NotFoundExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            // Si l'exception n'est pas de type « NotFoundException », on skip la procedure
            if (exception is not NotFoundException notFoundException)
            {
                return false;
            }

            // Création de l'erreur « Not Found » à envoyer
            var problemDetails = new ProblemDetails
            {
                Title = "An not found error occurred",
                Status = StatusCodes.Status404NotFound,
                Detail = exception.Message
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }
    }
}
