namespace backend.Helpers
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;

                switch (error)
                {
                    case AppException e:
                        response.StatusCode = e.StatusCode;
                        break;

                    case KeyNotFoundException:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    default:
                        // Fall back
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                await response.WriteAsJsonAsync(new { message = error?.Message });
            }
        }
    }
}
