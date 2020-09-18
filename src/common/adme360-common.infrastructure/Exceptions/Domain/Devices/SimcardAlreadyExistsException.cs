using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices
{
  public class SimcardAlreadyExistsException : Exception
  {
    private readonly string _iccid;
    private readonly string _imsi;


    public SimcardAlreadyExistsException(string iccid, string imsi)
    {
      _iccid = iccid;
      _imsi = imsi;
    }

    public override string Message => $" Simcard with Icci: {_iccid} or imsi:{_imsi} already Exists!";
  }
}