namespace magic.button.collector.api.Messaging.PortHandlers
{
  public interface IPortHandler
  {
    bool IsComPortOpen { get; }
    void ToggleComPort(string comPort);
    void SendPackage(byte[] package);
  }
}