using System.Security.AccessControl;

namespace Case2GK20221102.Errors;

public class ValidationErrorException : SystemException
{
    private string ErrorLayer { get; set; }
    private string ErrorPart { get; set; }
    public ValidationErrorException(string errorLayer, string errorPart)
    {
        ErrorLayer = errorLayer;
        ErrorPart = errorPart;
    }
}