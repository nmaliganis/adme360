namespace magic.button.collector.api.Messaging.PortHandlers
{
  public class PortHandlerFactory : IPortHandlerFactory
  {
    public IPortHandler CreatePortHandler()
    {
      return PortHandler.PortHandlerInsance;
    }
  }
}