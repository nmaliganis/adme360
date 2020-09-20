using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;
using adme360.models.DTOs.Employees;
using adme360.models.DTOs.Employees;

namespace adme360.models.DTOs.Users
{
    public class AccountErrorModel
    {
        public string errorMessage { get; set; }
    }


    public class UserUiModel : IUiModel
    {
        public UserUiModel()
        {
            Employee = new EmployeeForCreationUiModel();
        }

        [Key]
        public Guid Id { get; set; }

        [Editable(false)]
        public string Message { get; set; }
        [Required]
        [Editable(false)]
        public EmployeeForCreationUiModel Employee { get; set; }
        [Required]
        [Editable(false)]
        public string Login { get; set; }
        [Required]
        [Editable(false)]
        public string RefreshToken { get; set; }
        [Required]
        [Editable(false)]
        public string Token { get; set; }
        [Required]
        [Editable(false)]
        public Guid UserRoleId { get; set; }
    }
    public class AccountUiModel : UserUiModel
    {
        [Required]
        [Editable(false)]
        public string UserPassword { get; set; }
    }
}