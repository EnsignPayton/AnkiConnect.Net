namespace AnkiConnect.Net;

public class AnkiException : Exception
{
    public AnkiException()
    {
    }

    public AnkiException(string message) : base(message)
    {
    }

    public AnkiException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public AnkiException(Exception innerException) : base(string.Empty, innerException)
    {
    }
}
