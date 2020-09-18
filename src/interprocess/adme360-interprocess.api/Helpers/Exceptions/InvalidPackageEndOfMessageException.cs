using System;

namespace magic.button.collector.api.Helpers.Exceptions
{
  internal class InvalidPackageEndOfMessageException : Exception
  {
    private readonly byte[] _endOfMessage;

    public override string ToString()
    {
      return BuildMessage();
    }

    public override string Message => BuildMessage();

    private string BuildMessage()
    {
      return $"Invalid Package End of Message: {_endOfMessage[0]:X} {_endOfMessage[1]:X}";
    }

    public InvalidPackageEndOfMessageException(byte[] startOfMessage)
    {
      _endOfMessage = startOfMessage;
    }
  }
}
