using System;
using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Accounts
{
    public class AccountForActivationModification
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public Guid ActivationKey { get; set; }
    }
}