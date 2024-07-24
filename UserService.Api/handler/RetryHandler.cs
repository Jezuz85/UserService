using Polly;
using Polly.Retry;

namespace UserService.Api.handler
{
    public class RetryHandler : DelegatingHandler
    {
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;
        private readonly ILogger<RetryHandler> _logger;

        public RetryHandler(ILogger<RetryHandler> logger)
        {
            _logger = logger;
            _retryPolicy = RetryPolicy.GetRetryPolicy(logger);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await _retryPolicy.ExecuteAsync(async (context) =>
            {
                _logger.LogInformation($"Processing request to {request.RequestUri}");
                return await base.SendAsync(request, cancellationToken);
            }, new Context(request.RequestUri.ToString()));
        }
    }


    public class RetryPolicy
    {
        public static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy(ILogger logger)
        {
            return Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .Or<HttpRequestException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (outcome, timespan, retryAttempt, context) =>
                    {
                        logger.LogWarning($"Retry attempt {retryAttempt} for {context.PolicyKey} at {context.OperationKey}, due to: {outcome.Result?.StatusCode}.");
                    });
        }
    }
}