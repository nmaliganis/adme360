﻿using System;
using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Customers
{
  public class CustomerForDeletionUiModel
  {
    [Required]
    [Editable(true)]
    public Guid Id { get; set; }
    [Required]
    [Editable(true)]
    public bool IsActive { get; set; }
    [Required]
    [Editable(true)]
    public bool DeletionStatus { get; set; }
    [Required]
    [Editable(true)]
    public string Message { get; set; }
  }
}