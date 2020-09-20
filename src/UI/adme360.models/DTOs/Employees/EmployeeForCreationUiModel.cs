using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Employees
{
    public class EmployeeForCreationUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }

        [Editable(false)]
        public string Message { get; set; }
        [Required]
        [Editable(false)]
        public string Firstname { get; set; }
        [Required]
        [Editable(false)]
        public string Lastname { get; set; }
        [Required]
        [Editable(false)]
        public int GenderIndex { get; set; }
        [Required]
        [Editable(false)]
        public string GenderValue { get; set; }
        [Required]
        [Editable(false)]
        public string Email { get; set; }
        [Required]
        [Editable(false)]
        public string Phone { get; set; }
        [Required]
        [Editable(false)]
        public string ExtPhone { get; set; }
        [Required]
        [Editable(false)]
        public string Mobile { get; set; }
        [Required]
        [Editable(false)]
        public string ExtMobile { get; set; }
        [Editable(false)]
        public string Notes { get; set; }
        [Required]
        [Editable(false)]
        public string AddressStreetOne { get; set; }
        public string AddressStreetTwo { get; set; }
        [Required]
        [Editable(false)]
        public string AddressPostCode { get; set; }
        [Required]
        [Editable(false)]
        public string AddressCity { get; set; }
        public string AddressRegion { get; set; }
        [Required]
        [Editable(false)]
        public Guid EmployeeRoleId { get; set; }
        [Required]
        [Editable(false)]
        public Guid DepartmentId { get; set; }
    }
}