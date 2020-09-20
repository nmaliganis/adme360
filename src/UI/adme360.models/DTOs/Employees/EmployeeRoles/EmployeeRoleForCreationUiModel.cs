using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Employees.EmployeeRoles
{
    public class EmployeeRoleForCreationUiModel
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string EmployeeRoleName { get; set; }
        [Required]
        [Editable(true)]
        public int EmployeeRoleType { get; set; }
        [Editable(true)]
        public string EmployeeRoleNotes { get; set; }
    }

    public class EmployeeRoleForModificationUiModel : IUiModel
    {
        [Key] public Guid Id { get; set; }
        [Editable(true)] public string Message { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string EmployeeRoleName { get; set; }

        [Required] [Editable(true)] public int EmployeeRoleType { get; set; }
        [Editable(true)] public string EmployeeRoleNotes { get; set; }
    }
}