namespace magic.button.collector.api.Messaging.Checkers
{
  public interface IPackageChecker
  {
    void Check(byte[] package, byte? commandCode, bool bCheckCrc);
    bool IsEndOfReceivedPackage(byte[] package);
  }
}