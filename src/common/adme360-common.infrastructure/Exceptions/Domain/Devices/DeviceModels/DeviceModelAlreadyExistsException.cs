using System;

namespace adme360.common.infrastructure.Exceptions.Domain.Devices.DeviceModels
{
    public class DeviceModelAlreadyExistsException : Exception
    {

        public string DeviceModelName { get; }
        public string BrokenRules { get; }


        public DeviceModelAlreadyExistsException(string name, string brokenRules)
        {
          DeviceModelName = name;
          BrokenRules = brokenRules;
        }
        public override string Message => $" Device Model with Name: {DeviceModelName}" +
                                          $" already Exists!\n Additional info:{BrokenRules}";
    }
}