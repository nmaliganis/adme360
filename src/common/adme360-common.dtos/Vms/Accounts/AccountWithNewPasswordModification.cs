using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Accounts
{
    public class AccountWithNewPasswordModification
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Password { get; set; }
    }
}