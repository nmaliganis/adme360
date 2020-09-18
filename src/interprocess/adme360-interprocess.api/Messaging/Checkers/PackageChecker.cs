using System.Linq;
using magic.button.collector.api.Helpers.Exceptions;
using magic.button.collector.api.Messaging.PackageRepositories;

namespace magic.button.collector.api.Messaging.Checkers
{
  public sealed class PackageChecker : IPackageChecker
  {
    private static readonly PackageChecker _instance = new PackageChecker();
    private byte[] _package;

    private PackageChecker()
    {
    }

    public static IPackageChecker Checker => _instance;

    public void Check(byte[] package, byte? commandCode, bool bCheckCrc)
    {
      _package = package;
      CheckStartOfMessage();

      if (commandCode != null)
      {
        CheckCommandCode(commandCode);
      }


#if !DEBUG
            if (bCheckCrc)
            {
                CheckCrcOfMessage();
            }
#endif

      CheckEndOfMessage();
    }

    public bool IsEndOfReceivedPackage(byte[] package)
    {
      return (package.Length > 2)
             && (package.ElementAt(package.Length - 1) == PackageRepository.PackageRepositoryInstance.EndOfMessageCode);
    }

    private void CheckEndOfMessage()
    {
      if (_package[PackageRepository.
                          PackageRepositoryInstance.EndOfMessageOffset] !=  PackageRepository.PackageRepositoryInstance.EndOfMessageCode)
      {
        throw new InvalidPackageEndOfMessageException(
            new[]
                {
                            _package[PackageRepository.
                                PackageRepositoryInstance.EndOfMessageOffset]
                });
      }
    }

    private void CheckCrcOfMessage()
    {
      //Todo:
    }

    private void CheckCommandCode(byte? commandCode)
    {
      if (commandCode != null)
      {
        if (_package[PackageRepository.PackageRepositoryInstance.CommandOffset] != commandCode)
          throw new InvalidPackageCommandException(_package[PackageRepository.PackageRepositoryInstance.CommandOffset]);
      }
    }

    private void CheckStartOfMessage()
    {
      if (_package[PackageRepository.
                          PackageRepositoryInstance.StartOfMessageOffset] !=
          PackageRepository.PackageRepositoryInstance.StartOfMessageCode ||
          _package[PackageRepository.
                          PackageRepositoryInstance.StartOfMessageOffset + 1] !=
          PackageRepository.PackageRepositoryInstance.StartOfMessageCode)
      {
        throw new InvalidPackageStartOfMessageException(
            new[]
                {
                            _package[PackageRepository.
                                PackageRepositoryInstance.StartOfMessageOffset],
                            _package[PackageRepository.
                                PackageRepositoryInstance.StartOfMessageOffset + 1]
                });
      }
    }


  }
}
