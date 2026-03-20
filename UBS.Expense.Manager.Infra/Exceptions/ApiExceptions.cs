namespace UBS.Expense.Manager.Infra.Exceptions;

public class NotFoundException : CustomException
{
    public NotFoundException(string message) : base(message, 404) { }   
}

public class BadRequestException : CustomException
{
    public BadRequestException(string message) : base(message, 400) { }
}
