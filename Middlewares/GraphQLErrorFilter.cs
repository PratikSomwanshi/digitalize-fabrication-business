using System.Net;
using DigitalizeFabricationBussiness.Utilities.Exceptions;
using HotChocolate;
using HotChocolate.Execution;

namespace DigitalizeFabricationBussiness.Middleware;

/// <summary>
/// Custom error filter for GraphQL errors.
/// Removes GraphQL metadata (path, location) and adds business-friendly structure.
/// </summary>
public class GraphQLErrorFilter : IErrorFilter
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GraphQLErrorFilter(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public IError OnError(IError error)
    {
        // --- Handle business CustomException ---
        if (error.Exception is CustomException customException)
        {
            return CreateFilteredError(
                customException.Message,
                (int)customException.StatusCode,
                customException.Code
            );
        }

        // --- Handle authentication (no token / invalid token) ---
        if (error.Code == "AUTH_NOT_AUTHENTICATED")
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var hasToken = httpContext != null &&
                           !string.IsNullOrEmpty(httpContext.Request.Headers["Authorization"]);

            var message = hasToken ? "Invalid or expired token" : "Authentication token missing";

            return CreateFilteredError(message, 401, "UNAUTHORIZED");
        }

        // --- Handle authorization errors ---
        if (error.Code == "AUTH_NOT_AUTHORIZED")
        {
            return CreateFilteredError(
                "You do not have permission to access this resource",
                403,
                "FORBIDDEN"
            );
        }

        // --- Default handling for other exceptions ---
        if (error.Exception != null)
        {
            return CreateFilteredError(
                error.Exception.Message,
                500,
                "INTERNAL_SERVER_ERROR"
            );
        }

        // --- Fallback (unmodified) ---
        return CreateFilteredError(error.Message, 400, "BAD_REQUEST");
    }

    private static IError CreateFilteredError(string message, int statusCode, string errorCode)
    {
        // IMPORTANT: Do NOT set path or location
        return ErrorBuilder.New()
            .SetMessage(message)
            .SetExtension("statusCode", statusCode)
            .SetExtension("errorCode", errorCode)
            .Build();
    }
}
