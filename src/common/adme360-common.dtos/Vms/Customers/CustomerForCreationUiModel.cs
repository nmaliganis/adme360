using System;
using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Customers
{
    public class CustomerForCreationUiModel
    {
      [Required(AllowEmptyStrings = false)]
      [Editable(true)]
      public string CustomerFirstname { get; set; }
      [Required(AllowEmptyStrings = false)]
      [Editable(true)]
      public string CustomerLastname { get; set; }
      [Required(AllowEmptyStrings = false)]
      [Editable(true)]
      public string CustomerBrand { get; set; }
      [Required(AllowEmptyStrings = false)]
      [Editable(true)]
      public string CustomerEmail { get; set; }
      [Required(AllowEmptyStrings = false)]
      [Editable(true)]
      public string CustomerPhone { get; set; }
      [Required(AllowEmptyStrings = false)]
      [Editable(true)]
      public string CustomerVat { get; set; }
      [Editable(true)]
      public string CustomerWebsite { get; set; }
      [Required(AllowEmptyStrings = false)]
      [Editable(true)]
      public string CustomerNotes { get; set; }
      public string CustomerStreetOne { get; set; }
      [Editable(true)]
      public string CustomerStreetTwo { get; set; }
      [Required(AllowEmptyStrings = false)]
      [Editable(true)]
      public string CustomerPostCode { get; set; }
      [Required(AllowEmptyStrings = false)]
      [Editable(true)]
      public string CustomerCity { get; set; }
      [Required(AllowEmptyStrings = false)]
      [Editable(true)]
      public string CustomerRegion { get; set; }

      [Required(AllowEmptyStrings = false)]
      [Editable(true)]
      public string CustomerUserLogin { get; set; }
      [Required(AllowEmptyStrings = false)]
      [Editable(true)]
      public string CustomerUserPassword { get; set; }

      [Required]
      [Editable(true)]
      public Guid CustomerCategoryId { get; set; }
    }
}
