namespace ValidatorWithDataBuilder.Domain.CustomerAggregate.Exceptions;

public class BadRequestException : Exception
{
    private IDictionary<string, string[]> _errors;

    public BadRequestException(IDictionary<string, string[]> errors)
    {
        _errors = errors;
    }

    public IDictionary<string, string[]> GetErrors() => _errors;
}