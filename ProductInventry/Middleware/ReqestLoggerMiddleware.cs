namespace ProductInventry.Middleware
{
    public class ReqestLoggerMiddleware
    {
        private readonly  RequestDelegate _next;
        private readonly ILogger<ReqestLoggerMiddleware> _logger;
        public ReqestLoggerMiddleware(RequestDelegate next, ILogger<ReqestLoggerMiddleware> logger)
        {
            _next = next;

            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"req is come at {DateTime.Now}");
            
            await _next(context);
        }
    }
}
