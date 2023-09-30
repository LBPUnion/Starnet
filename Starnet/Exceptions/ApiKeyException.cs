namespace LBPUnion.Starnet.Exceptions;

public class ApiKeyException : Exception
{
    /// <summary>
    ///     Should be thrown when the API key is invalid.
    /// </summary>
    /// <param name="message">Additional information to explain what caused the exception.</param>
    public ApiKeyException(string message) : base(message)
    { }
}