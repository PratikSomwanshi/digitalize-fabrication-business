using System.Net;

namespace DigitalizeFabricationBussiness.Utilities.Responses;

public class ErrorResponse(string message)
{
    public bool Status { get; } = false;
    public string Message { get; set; } = message;

}