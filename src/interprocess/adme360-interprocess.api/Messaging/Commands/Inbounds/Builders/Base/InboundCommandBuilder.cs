using System;
using System.Globalization;
using System.Text;
using magic.button.collector.api.Messaging.PackageRepositories;

namespace magic.button.collector.api.Messaging.Commands.Inbounds.Builders.Base
{
  public abstract class InboundCommandBuilder
  {
    public string Message { get; set; }
    public string  SerialNumberValue { get; set; }
    public string  CommandTypeValue { get; set; }
    public string  TempValue { get; set; }
    public string  BatValue { get; set; }
    public string  RssiValue { get; set; }
    public string  SnrValue { get; set; }
    public abstract void BuildPayload();


    protected virtual string BuildMessage(byte[] mbPackage)
    {
      ExtractSerialNumber(mbPackage);
      ExtractCommandType(mbPackage);
      ExtractTemp(mbPackage);
      ExtractBat(mbPackage);
      ExtractRssi(mbPackage);
      ExtractSnr(mbPackage);
      BuildPayload();
      return Message;
    }

    protected virtual string ExtractSerialNumber(byte[] mbPackage)
    {
      byte[] serialNumberBuffer = new byte[PackageRepository.PackageRepositoryInstance.DeviceIdLen];
      Array.Copy(mbPackage, PackageRepository.PackageRepositoryInstance.DeviceIdOffset, serialNumberBuffer, 0,
        PackageRepository.PackageRepositoryInstance.DeviceIdLen);

      StringBuilder builder = new StringBuilder();
      foreach (var t in serialNumberBuffer)
      {
        builder.Append(t.ToString("x2"));
      }

      SerialNumberValue = builder.ToString();
      return SerialNumberValue;
    }

    protected virtual string ExtractCommandType(byte[] mbPackage)
    {
      byte[] commandTypeBuffer = new byte[PackageRepository.PackageRepositoryInstance.PayloadTelemetryCommandTypeLength];
      Array.Copy(mbPackage, PackageRepository.PackageRepositoryInstance.PayloadTelemetryCommandTypeOffset,
        commandTypeBuffer, 0,
        PackageRepository.PackageRepositoryInstance.PayloadTelemetryCommandTypeLength);

      StringBuilder builder = new StringBuilder();
      foreach (var t in commandTypeBuffer)
      {
        builder.Append(t.ToString("x2"));
      }

      CommandTypeValue = builder.ToString();
      return CommandTypeValue;
    }

    protected virtual string ExtractTemp(byte[] mbPackage)
    {
      byte[] tempBuffer = new byte[PackageRepository.PackageRepositoryInstance.PayloadTelemetryTempLength];
      Array.Copy(mbPackage, PackageRepository.PackageRepositoryInstance.PayloadTelemetryTempOffset,
        tempBuffer, 0,
        PackageRepository.PackageRepositoryInstance.PayloadTelemetryTempLength);

      double temperature =  (double)(Convert.ToDecimal(tempBuffer[0].ToString("x2"))  + Decimal.Divide(tempBuffer[1], 10)); 

      TempValue = temperature.ToString(CultureInfo.InvariantCulture);
      return TempValue;
    }

    protected virtual string ExtractBat(byte[] mbPackage)
    {
      byte[] batBuffer = new byte[PackageRepository.PackageRepositoryInstance.PayloadTelemetryBatteryLength];
      Array.Copy(mbPackage, PackageRepository.PackageRepositoryInstance.PayloadTelemetryBatteryOffset,
        batBuffer, 0,
        PackageRepository.PackageRepositoryInstance.PayloadTelemetryBatteryLength);

      double battery =  (double)(Convert.ToDecimal(batBuffer[0].ToString("x1"))  + Decimal.Divide(batBuffer[1], 10)); 

      BatValue = battery.ToString(CultureInfo.InvariantCulture);
      return BatValue;
    }

    protected virtual string ExtractRssi(byte[] mbPackage)
    {
      byte[] rssiBuffer = new byte[PackageRepository.PackageRepositoryInstance.PayloadTelemetryRssiLength];
      Array.Copy(mbPackage, PackageRepository.PackageRepositoryInstance.PayloadTelemetryRssiOffset,
        rssiBuffer, 0,
        PackageRepository.PackageRepositoryInstance.PayloadTelemetryRssiLength);

      StringBuilder builder = new StringBuilder();
      foreach (var t in rssiBuffer)
      {
        builder.Append(t.ToString("x2"));
      }

      RssiValue = builder.ToString();
      return RssiValue;
    }

    protected virtual string ExtractSnr(byte[] mbPackage)
    {
      byte[] snrBuffer = new byte[PackageRepository.PackageRepositoryInstance.PayloadTelemetrySnrLength];
      Array.Copy(mbPackage, PackageRepository.PackageRepositoryInstance.PayloadTelemetrySnrOffset,
        snrBuffer, 0,
        PackageRepository.PackageRepositoryInstance.PayloadTelemetrySnrLength);

      StringBuilder builder = new StringBuilder();
      foreach (var t in snrBuffer)
      {
        builder.Append(t.ToString("x2"));
      }

      SnrValue = builder.ToString();
      return SnrValue;
    }
  }
}
