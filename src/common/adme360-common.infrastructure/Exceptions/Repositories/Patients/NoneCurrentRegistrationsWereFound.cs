using System;

namespace adme360.common.infrastructure.Exceptions.Repositories.Patients
{
    public class NoneCurrentRegistrationsWereFound : Exception
    {
        public Guid PatientId { get; set; }
        public Guid DeviceId { get; set; }

        public string Details { get; set; }

        public NoneCurrentRegistrationsWereFound(Guid patientId, Guid deviceId)
        {
            this.PatientId = patientId;
            this.DeviceId = deviceId;
        }

        public override string Message => $"None Registrations for Patient: {PatientId} and Device:{DeviceId} were found";
    }

}
