namespace Forge.Core.Logger;

/// <summary>
/// Interface defining basic logging operations in the Forge.Core.Logger library.
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Logs a message at the Information level.
    /// </summary>
    /// <param name="message">The message content to be logged.</param>
    void LogInformation(string message);

    /// <summary>
    /// Logs a message at the Warning level.
    /// </summary>
    /// <param name="message">The message content to be logged.</param>
    void LogWarning(string message);

    /// <summary>
    /// Logs a message at the Error level with an optional exception.
    /// </summary>
    /// <param name="message">The message content to be logged.</param>
    /// <param name="exception">An optional exception related to the error, can be null.</param>
    void LogError(string message, Exception? exception = null);
}