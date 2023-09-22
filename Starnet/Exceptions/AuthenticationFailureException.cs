namespace LBPUnion.Starnet.Exceptions;

public class AuthenticationFailureException : Exception
{
    public AuthenticationFailureException(string message) : base(message)
    { }
}