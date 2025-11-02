namespace DigitalizeFabricationBussiness.Utilities.Responses;

public class SuccessResponse<T>(string message, T data)
{
    public bool Status { get; set; } = true;
    public string Message { get; set; } = message;
    public T Data { get; set; } = data;

}