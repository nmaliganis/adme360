namespace magic.button.collector.api.Messaging.PackageRepositories
{
  public class PackageRepository
  {
    private static readonly PackageRepository _instance = new PackageRepository();

    private PackageRepository()
    {
    }

    public static PackageRepository PackageRepositoryInstance => _instance;

    //{{}}
    //7B7B AEEA123241 54 0001020304050607080910111213141516171819 F3 7D 7D

    //7B7BAEEA123241540001020304050607080910111213141516171819F37D7D
    //7B7BAEEA123241540102093604324565780000000000000000000000F37D7D
    #region Commnad Definitions --->

    public char StartOfMessageCode => '{';
    public char EndOfMessageCode => '}';
    public char AckCode => '@';
    public char NackCode => '!';
    public char TelemetryCmdCode => 'T';

    #endregion

    #region Command Offsets --->

    public byte StartOfMessageOffset => 0;
    public byte DeviceIdOffset => (byte)(StartOfMessageOffset + StartOfMessageLen);
    public byte CommandOffset => (byte)(DeviceIdOffset + DeviceIdLen);
    public byte MessageOffset => (byte)(CommandOffset + CommandLen);
    public byte PayloadTelemetryCommandTypeOffset => (byte)(CommandOffset + CommandLen);
    public byte PayloadTelemetryBatteryOffset => (byte)(PayloadTelemetryCommandTypeOffset + PayloadTelemetryCommandTypeLength);
    public byte PayloadTelemetryTempOffset => (byte)(PayloadTelemetryBatteryOffset + PayloadTelemetryBatteryLength);
    public byte PayloadTelemetryRssiOffset => (byte)(PayloadTelemetryTempOffset + PayloadTelemetryTempLength);
    public byte PayloadTelemetrySnrOffset => (byte)(PayloadTelemetryRssiOffset + PayloadTelemetryRssiLength);
    public byte CrcOffset => (byte)(MessageOffset + MessageLen);
    public byte EndOfMessageOffset => (byte)(CrcOffset + CrcLen);

    #endregion

    public byte CommandTypePressButtonCode => 0x01;
    public byte CommandTypeTempMeasurementCode => 0x02;
    public byte CommandTypeBatAlertCode => 0x03;
    public byte CommandTypeTamperCode => 0x04;

    public int PayloadTelemetryCommandTypeLength => 1;
    public int PayloadTelemetryBatteryLength => 2;
    public int PayloadTelemetryTempLength => 2;
    public int PayloadTelemetryRssiLength => 2;
    public int PayloadTelemetrySnrLength => 2;

    public byte StartOfMessageLen => 2;
    public byte DeviceIdLen => 5;
    public byte CommandLen => 1;
    public byte MessageLen => 20;
    public byte CrcLen => 1;
    public byte EndOfMessageLen => 2;

    public byte PackageLen =>
      (byte)(StartOfMessageLen + DeviceIdLen + CommandLen +
             MessageLen + CrcLen + EndOfMessageLen);

    public byte PackageToBeCheckedForCrcLen =>
      (byte)(DeviceIdLen + CommandLen +
             MessageLen);

    private byte NullValue => 0xEE;
    public byte[] NullMessage => FillMessageWithNulls();

    private byte[] FillMessageWithNulls()
    {
      var nullMessage = new byte[MessageLen];

      for (int i = 0; i < MessageLen; i++)
      {
        nullMessage[i] = NullValue;
      }

      return nullMessage;
    }
  }
}
