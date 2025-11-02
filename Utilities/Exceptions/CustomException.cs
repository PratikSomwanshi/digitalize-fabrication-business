using System.Net;
using DigitalizeFabricationBussiness.Utilities.Enumes;

namespace DigitalizeFabricationBussiness.Utilities.Exceptions;

public class CustomException: Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public new string Message { get; set; } = string.Empty;
    
    public string Code { get; set; } = string.Empty;

    public CustomException(HttpStatusCode statusCode, string message, ErrorCode code):base(message)
    {
        this.StatusCode = statusCode;
        this.Message = message;
        this.Code = code.ToString();
    }
}