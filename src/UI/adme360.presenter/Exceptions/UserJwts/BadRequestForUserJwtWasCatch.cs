using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dl.wm.presenter.Exceptions.UserJwts
{
    public class BadRequestForUserJwtWasCatch : Exception
    {
        public string MessageExc { get; private set; }

        public BadRequestForUserJwtWasCatch(string message)
        {
            MessageExc = message;
        }

        public override string Message => $"User Authentication error. Details:{Message}";
    }
}
