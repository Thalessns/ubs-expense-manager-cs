namespace UBS.Expense.Manager.Infra.Exceptions;

public abstract class CustomException : Exception
{
    public int StatusCode { get;  private set; }

    public CustomException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}
