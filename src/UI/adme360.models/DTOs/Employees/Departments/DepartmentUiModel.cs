using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Employees.Departments
{
    public class DepartmentUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }
        [Editable(true)]
        public string Message { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Name { get; set; }
        [Editable(false)]
        public string CreatedDate { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(false)]
        public string ModifiedDate { get; set; }
        [Required]
        [Editable(false)]
        public string Active { get; set; }
    }
}