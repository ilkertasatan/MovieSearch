using System.Net;
using Flurl.Http;
using Polly;
using Polly.Retry;

namespace MovieSearch.Infrastructure.Helpers;

public static class HttpRetryPolicy
{
    public static AsyncRetryPolicy BuildRetryPolicy()
    {
        return Policy
            .Handle<FlurlHttpException>(IsTransientError)
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

    private static bool IsTransientError(FlurlHttpException exception)
    {
        int[] httpStatusCodesWorthRetrying =
        [
            (int)HttpStatusCode.RequestTimeout,
            (int)HttpStatusCode.BadGateway,
            (int)HttpStatusCode.ServiceUnavailable,
            (int)HttpStatusCode.GatewayTimeout
        ];

        return exception.StatusCode.HasValue &&
               httpStatusCodesWorthRetrying.Contains(exception.StatusCode.Value);
    }
}