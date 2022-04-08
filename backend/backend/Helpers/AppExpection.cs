
namespace backend.Helpers
{
    /// <summary>
    /// <para>
    /// Common error class to handle typical API errors e.g. validation or business logic errors.
    /// </para>
    /// <para>
    /// When thorwn, sends <c>message</c> and <c>status code</c> to client
    /// </para>
    /// </summary>
    public class AppException : Exception
    {
        public int StatusCode { get; }

        public AppException(string message, int errorCode) : base(message)
        {
            StatusCode = errorCode;
        }
    }
}
