namespace SenhasGpt.Domain.Exceptions;
[Serializable]
public class GptException : InvalidOperationException
{
    public string DisplayMessage { get; }

    public GptException(string message) : base(message)
        => DisplayMessage = message;

    public GptException(string message, string displayMessage) : base(message)
        => DisplayMessage = displayMessage;
}
