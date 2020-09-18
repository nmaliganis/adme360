using System;
using System.ComponentModel.DataAnnotations;
using adme360.common.dtos.Vms.Bases;

namespace adme360.common.dtos.Vms.Customers
{
    public class CustomerUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }
        [Editable(true)]
        public string Message { get; set; }

    
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerFirstname { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerLastname { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerEmail { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerBrand { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerPhone { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerVat { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerWebsite { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerNotes { get; set; }

        [Required]
        [Editable(true)]
        public DateTime CustomerCreatedDate { get; set; }
        [Required]
        [Editable(true)]
        public DateTime CustomerModifiedDate { get; set; }
        [Required]
        [Editable(true)]
        public Guid CustomerCreatedBy { get; set; }
        [Required]
        [Editable(true)]
        public Guid CustomerModifiedBy { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerAddressStreetOne { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerAddressStreetTwo { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerAddressPostcode { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerAddressCity { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerAddressRegion { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public bool CustomerActivated { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public bool CustomerActive { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public Guid CustomerCategoryId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerCategoryName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CustomerCategoryType { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public int CustomerCategoryTypeValue { get; set; }
    }
}
