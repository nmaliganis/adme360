using System;
using System.ComponentModel.DataAnnotations;

namespace adme360.models.DTOs.Users.Accounts
{
    public class UserForRegistrationUiModel
    {
        //UserModel
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Login { get; set; }
        [MaxLength(100)]
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Password { get; set; }
        
        
        //EmployeeModel
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Firstname { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Lastname { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Email { get; set; }
        [Required]
        [Editable(true)]
        public int Gender { get; set; }
        [Required]
        [Editable(true)]
        public string GenderValue { get; set; }
        [Editable(true)]
        public string Phone { get; set; }
        [Editable(true)]
        public string ExtPhone { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Mobile { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string ExtMobile { get; set; }
        [Editable(true)]
        public string Notes { get; set; }

        //AddressModel
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string AddressStreetOne { get; set; }
        [Editable(true)]
        public string AddressStreetTwo { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string AddressPostCode { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string AddressCity { get; set; }
        [Editable(true)]
        public string AddressRegion { get; set; }
        
        
        //Dependencies Model
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public Guid UserRoleId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public Guid EmployeeRoleId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public Guid DepartmentId { get; set; }
    }
}
