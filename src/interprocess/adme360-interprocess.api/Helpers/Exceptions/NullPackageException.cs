using System;

namespace magic.button.collector.api.Helpers.Exceptions
{
  public class NullPackageException : Exception
  {
    public override string ToString()
    {
      return BuildMessage();
    }

    public override string Message => BuildMessage();

    private string BuildMessage()
    {
      return "Null package exception";
    }
  }
}