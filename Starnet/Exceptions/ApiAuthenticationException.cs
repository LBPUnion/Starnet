namespace LBPUnion.Starnet.Exceptions;

public class ApiAuthenticationException : Exception
{
    /// <summary>
    ///     Should be thrown when API authentication fails (403).
    /// </summary>
    /// <param name="message">Additional information to explain what caused the exception.</param>
    public ApiAuthenticationException(string message) : base(message)
    { }
}