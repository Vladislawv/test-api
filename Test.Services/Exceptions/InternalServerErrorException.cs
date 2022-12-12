using System.Net;

namespace Test.Services.Exceptions;

public class InternalServerErrorException : CustomException
{
    private const HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;
    
    public InternalServerErrorException(string message) : base(message, StatusCode)
    {
    }
}