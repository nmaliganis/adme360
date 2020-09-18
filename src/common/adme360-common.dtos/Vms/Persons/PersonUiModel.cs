using System;
using System.ComponentModel.DataAnnotations;
using adme360.common.dtos.Vms.Bases;

namespace adme360.common.dtos.Vms.Persons
{
    public class PersonUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }
        [Editable(true)]
        public string Message { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string LastName { get; set; }
        [Editable(false)]
        public string CreatedDate { get; set; }
    }
}
