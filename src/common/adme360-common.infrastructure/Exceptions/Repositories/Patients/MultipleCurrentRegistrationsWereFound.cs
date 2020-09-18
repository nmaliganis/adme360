using System;

namespace adme360.common.infrastructure.Exceptions.Repositories.Patients
{
    public class MultipleCurrentRegistrationsWereFound : Exception
    {
        public Guid PatientId { get; set; }
        public Guid DeviceId { get; set; }
        public int RegistrationCount { get; set; }

        public string Details { get; set; }

        public MultipleCurrentRegistrationsWereFound(Guid patientId, Guid deviceId, int registrationCount)
        {
            this.RegistrationCount = registrationCount;
        }

        public override string Message => "Multiple Registrations for Patient and Device were found .\nDetails:" + RegistrationCount;
    }

}
