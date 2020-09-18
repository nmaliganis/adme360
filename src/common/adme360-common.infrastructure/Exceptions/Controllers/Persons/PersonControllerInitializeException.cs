using System;

namespace adme360.common.infrastructure.Exceptions.Controllers.Persons
{
    public class PersonControllerInitializeException : Exception
    {
        public PersonControllerInitializeException()
        {
        }

        public override string Message => $" Person Controller initialization failed!";
    }
}
