using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Employees.EmployeeRoles
{
    public class EmployeeRoleErrorModel
    {
        public string errorMessage { get; set; }
    }

    public enum EmployeeRoleType 
    {
        Supervisor = 1,
        Driver,
        Cleaner,
        Other,
    }

    public class EmployeeRoleUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }
        [Editable(true)]
        public string Message { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Notes { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public EmployeeRoleType Type { get; set; }
        [Editable(false)]
        public string CreatedDate { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string ModifiedDate { get; set; }
        [Required]
        [Editable(false)]
        public bool Active { get; set; }
    }
}