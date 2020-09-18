using System;
using System.Net;
using System.Text;
using magic.button.collector.api.Helpers.Models;
using magic.button.collector.api.Helpers.Serializers;
using magic.button.collector.api.Messaging.Commands.Inbounds.Builders.Base;
using magic.button.collector.api.Messaging.Commands.Inbounds.Cmds;
using magic.button.collector.api.Messaging.Commands.Inbounds.Cmds.Base;

namespace magic.button.collector.api.Messaging.Commands.Inbounds.Builders
{
  public class TelemetryPackageDetectedInboundCommandBuilder : InboundCommandBuilder, IInboundCommandBuilder
  {
    private byte[] _package;
    private IJsonSerializer _jsonSerializer;

    public InboundCommand Build(byte[] package)
    {
      _jsonSerializer = new JSONSerializer();
      _package = package;
      return new TelemetryDetected(BuildMessage(package), "mb/telemetry/message");
    }

    public override void BuildPayload()
    {
      string deviceIdString = SerialNumberValue;
      string rssiString = RssiValue;
      string snrString = SnrValue;
      string buttonStatus  = CommandTypeValue;
      double tempValue  = Convert.ToDouble(TempValue);
      double batValue  = Convert.ToDouble(BatValue);

      TelemetryModel model = new TelemetryModel()
      {
        deviceid = deviceIdString,
        correlationId  = Guid.NewGuid(),
        timestamp = DateTime.Now,
        buttonStatus = buttonStatus,
        batValue = batValue,
        tempValue = tempValue,
        rssi = rssiString,
        snr = snrString,
      };

      Message = _jsonSerializer.SerializeObject(model);
    }
  }
}