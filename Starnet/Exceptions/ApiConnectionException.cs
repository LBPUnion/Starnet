namespace LBPUnion.Starnet.Exceptions;

public class ApiConnectionException : Exception
{
    /// <summary>
    ///     Should be thrown when API connection fails with a non-200 status code.
    /// </summary>
    /// <param name="message">Additional information to explain what caused the exception.</param>
    public ApiConnectionException(string message) : base(message)
    { }   
}