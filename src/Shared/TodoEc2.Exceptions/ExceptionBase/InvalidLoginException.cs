namespace TodoEc2.Exceptions.ExceptionBase
{
    public class InvalidLoginException : TodoEc2Exceptions
    {
        public InvalidLoginException() : base("Email e/ou senha invalido!")
        {
            
        }
    }
}
