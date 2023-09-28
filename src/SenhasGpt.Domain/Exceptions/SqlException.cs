namespace SenhasGpt.Domain.Exceptions;
[Serializable]
public class SqlException : InvalidOperationException
{
    public string DisplayMessage { get; }

    public SqlException(string message) : base(message)
        => DisplayMessage = message;

    public SqlException(string message, string displayMessage) : base(message)
        => DisplayMessage = displayMessage;
}
