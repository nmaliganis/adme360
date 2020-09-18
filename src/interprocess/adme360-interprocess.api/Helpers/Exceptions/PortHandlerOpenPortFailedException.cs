using System;

namespace magic.button.collector.api.Helpers.Exceptions
{
  public class PortHandlerOpenPortFailedException : Exception
  {
    public override string ToString()
    {
      return BuildMessage();
    }

    public override string Message => BuildMessage();

    private string BuildMessage()
    {
      return "Serial port open failed failed.";
    }
  }
}