using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices
{
  public class InvalidSerialNumberForDeviceMeasurementException : Exception
  {
    public override string Message => $" Invalid Serial Number for Device Store Measurements";
  }

  public class InvalidMeasurementModelForDeviceMeasurementException : Exception
    {
      public override string Message => $" Invalid Measurement Model for Device Store Measurements";
    }
}