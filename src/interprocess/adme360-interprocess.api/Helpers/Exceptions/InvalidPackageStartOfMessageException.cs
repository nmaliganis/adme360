using System;

namespace magic.button.collector.api.Helpers.Exceptions
{
  internal class InvalidPackageStartOfMessageException : Exception
  {
    private readonly byte[] _startOfMessage;

    public override string ToString()
    {
      return BuildMessage();
    }

    public override string Message => BuildMessage();

    private string BuildMessage()
    {
      return $"Invalid Package Start of Message: {_startOfMessage[0]:X} {_startOfMessage[1]:X}";
    }

    public InvalidPackageStartOfMessageException(byte[] startOfMessage)
    {
      _startOfMessage = startOfMessage;
    }
  }
}