
namespace backend.Helpers
{
    public class AppException : Exception
    {
        public int StatusCode { get; }


        public AppException(string message, int errorCode) : base(message)
        {
            StatusCode = errorCode;
        }

    }
}
