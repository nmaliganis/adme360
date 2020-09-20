using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Users.Roles;

namespace adme360.models.DTOs.Users
{
    public class UserForAllRetrievalUiModel
    {
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
        public List<UserRoleUiModel> Roles { get; set; }
        [Required]
        [Editable(true)]
        public string ActivationKey { get; set; }
        [Required]
        [Editable(true)]
        public bool IsActivated { get; set; }
        [Required]
        [Editable(false)]
        public string CreatedBy { get; set; }
        [Required]
        [Editable(false)]
        public string ModifiedBy { get; set; }
        [Required]
        [Editable(false)]
        public DateTime CreateDate { get; set; }
        [Required]
        [Editable(false)]
        public string ResetKey{ get; set; }
        [Required]
        [Editable(false)]
        public string ResetDate { get; set; }
        [Editable(false)]
        public string LastModifiedBy { get; set; }
        [Required]
        [Editable(false)]
        public DateTime LastModifiedDate { get; set; }


        [Required]
        [Editable(false)]
        public string Firstname { get; set; }
        [Required]
        [Editable(false)]
        public string Lastname { get; set; }
        [Required]
        [Editable(false)]
        public string Gender { get; set; }

        [Required]
        [Editable(false)]
        public string ComposedPhone => $"{ExtPhone}{Phone}";
        [Required]
        [Editable(false)]
        public string Phone { get; set; }
        [Required]
        [Editable(false)]
        public string ExtPhone { get; set; }
        [Required]
        [Editable(false)]
        public string Notes { get; set; }
        [Required]
        [Editable(false)]
        public string AddressStreetOne { get; set; }
        [Required]
        [Editable(false)]
        public string AddressStreetTwo { get; set; }
        [Required]
        [Editable(false)]
        public string AddressCity { get; set; }
        [Required]
        [Editable(false)]
        public string AddressPostcode { get; set; }
        [Required]
        [Editable(false)]
        public string AddressRegion { get; set; }
        [Required]
        [Editable(false)]
        public Guid EmployeeRoleId { get; set; }
        [Required]
        [Editable(false)]
        public string EmployeeRoleName { get; set; }
        [Required]
        [Editable(false)]
        public Guid DepartmentId { get; set; }
        [Required]
        [Editable(false)]
        public string DepartmentName { get; set; }

    }
}