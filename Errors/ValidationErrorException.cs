namespace Case2GK20221102.Errors;

public class ValidationErrorException : SystemException
{
    public ValidationErrorException()
    {
        //TODO: Validation error fırlatıldığında errorun hangi error olduğuna yönelik bir bilgi de burada tutmalısın. parametre olarak constructurda alıp içeriye verebilirsin.
        //TODO: Ayrıca hangi servis veya katmanın bu hatayı fırlattığı bilgisini de yine constructer'dan isteyip içeride saklayabilirsin.
    }
}