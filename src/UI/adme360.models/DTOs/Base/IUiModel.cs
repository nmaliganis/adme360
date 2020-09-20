using System;
using System.ComponentModel.DataAnnotations;

namespace adme360.models.DTOs.Base
{
    public interface IUiModel
    {
        [Key]
        Guid Id { get; set; }
        [Editable(false)]
        string Message { get; set; }
    }
}