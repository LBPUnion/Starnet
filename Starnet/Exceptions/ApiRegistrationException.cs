namespace LBPUnion.Starnet.Exceptions;

public class ApiRegistrationException : Exception
{
    /// <summary>
    ///     Should be thrown when registration is disabled on the server.
    /// </summary>
    /// <param name="message">Additional information to explain what caused the exception.</param>
    public ApiRegistrationException(string message) : base(message)
    { }
}