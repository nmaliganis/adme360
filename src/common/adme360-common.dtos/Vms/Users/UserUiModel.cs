using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using adme360.common.dtos.Vms.Roles;

namespace adme360.common.dtos.Vms.Users
{
    public class UserUiModel
    {
        [Editable(true)]
        public string Message { get; set; }

        [Required]
        [Editable(true)]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Login { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public List<RoleUiModel> Roles { get; set; }
        [Required]
        [Editable(true)]
        public bool IsActivated { get; set; }
        [Required]
        [Editable(false)]
        public string CreatedBy { get; set; }
        [Required]
        [Editable(false)]
        public DateTime CreateDate { get; set; }
        [Editable(false)]
        public string ResetDate { get; set; }
        [Editable(false)]
        public string LastModifiedBy { get; set; }
        [Required]
        [Editable(false)]
        public DateTime LastModifiedDate { get; set; }
    }
}