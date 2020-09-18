using System;

namespace magic.button.collector.api.Helpers.Exceptions
{
  internal class InvalidPackageCommandException : Exception
  {
    private readonly byte? _commandCode;

    public InvalidPackageCommandException(byte? commandCode)
    {
      _commandCode = commandCode;
    }

    public override string Message => BuildMessage();

    public override string ToString()
    {
      return BuildMessage();
    }

    private string BuildMessage()
    {
      return $"Invalid package command code: {_commandCode:X}.";
    }
  }
}