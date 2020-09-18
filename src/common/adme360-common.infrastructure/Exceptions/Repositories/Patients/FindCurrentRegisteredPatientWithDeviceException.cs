using System;

namespace adme360.common.infrastructure.Exceptions.Repositories.Patients
{
    public class FindCurrentRegisteredPatientWithDeviceException : Exception
    {
        public Guid PatientId { get; set; }
        public Guid DeviceId { get; set; }

        public string Details { get; set; }

        public FindCurrentRegisteredPatientWithDeviceException(string details)
        {
            this.Details = details;
        }

        public override string Message => "Current Registration for Patient and Device failed .\nDetails:" + Details;
    }
}
