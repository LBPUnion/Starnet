namespace LBPUnion.Starnet.Exceptions;

public abstract class AuthenticationFailureException : Exception
{
    protected AuthenticationFailureException(string message) : base(message)
    { }
}