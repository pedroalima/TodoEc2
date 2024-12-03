namespace TodoEc2.Exceptions.ExceptionBase
{
    public class ErrorOnValidationException : TodoEc2Exceptions
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
