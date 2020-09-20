using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;
using adme360.models.DTOs.Employees.Departments;
using adme360.models.DTOs.Employees.EmployeeRoles;

namespace adme360.models.DTOs.Employees
{
    public class EmployeeUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }
        [Editable(true)]
        public string Message { get; set; }

    
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string EmployeeFirstname { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string EmployeeLastname { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string EmployeeEmail { get; set; }

        [Required]
        [Editable(true)]
        public int EmployeeStatus
        {
            get => 1;
            set {}
        }

        [Required]
        [Editable(true)]
        public string EmployeeStatusValue
        {
            get => "Normal";
            set {}
        }
        [Required]
        [Editable(true)]
        public int EmployeeGender { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string EmployeeGenderValue { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string EmployeePhone { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string EmployeeMobile { get; set; }
        [Editable(true)]
        public string EmployeeNotes { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string EmployeeAddress1 { get; set; }
        public string EmployeeAddress2 { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string EmployeeCity { get; set; }
        [Editable(true)]
        public string EmployeeRegion { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string EmployeePostcode { get; set; }


        [Required]
        [Editable(true)]
        public DateTime EmployeeCreatedDate { get; set; }
        [Required]
        [Editable(true)]
        public DateTime EmployeeModifiedDate { get; set; }
        [Required]
        [Editable(true)]
        public Guid EmployeeCreatedBy { get; set; }
        [Required]
        [Editable(true)]
        public Guid EmployeeModifiedBy { get; set; }
        
        [Required]
        [Editable(true)]
        public EmployeeRoleUiModel EmployeeEmployeeRole { get; set; }
        [Required]
        [Editable(true)]
        public DepartmentUiModel EmployeeDepartment { get; set; }
    }
}
