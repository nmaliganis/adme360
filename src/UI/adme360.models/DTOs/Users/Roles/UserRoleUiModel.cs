using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Users.Roles
{
    public class UserRoleUiModel : IUiModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Message { get; set; }

        [Required]
        [Editable(false)]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [Editable(true)]
        public DateTime ModifiedDate { get; set; }
        [Required]
        [Editable(true)]
        public bool Active { get; set; }
    }
}