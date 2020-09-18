using System;
using System.ComponentModel.DataAnnotations;
using adme360.common.dtos.Vms.Bases;

namespace adme360.common.dtos.Vms.Categories
{
    public class CategoryUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }
        [Editable(true)]
        public string Message { get; set; }

    
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CategoryName { get; set; }

        [Required]
        [Editable(true)]
        public DateTime CategoryCreatedDate { get; set; }
        [Required]
        [Editable(true)]
        public DateTime CategoryModifiedDate { get; set; }
        [Required]
        [Editable(true)]
        public Guid CategoryCreatedBy { get; set; }
        [Required]
        [Editable(true)]
        public Guid CategoryModifiedBy { get; set; }
    }
}
