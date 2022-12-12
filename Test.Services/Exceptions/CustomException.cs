using System.Net;

namespace Test.Services.Exceptions;

public class CustomException : Exception
{
    public HttpStatusCode ResponseStatusCode { get; }

    protected CustomException(string message, HttpStatusCode responseStatusCode) : base(message)
    {
        ResponseStatusCode = responseStatusCode;
    }
}