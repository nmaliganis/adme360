using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Firmwares
{
    public class FirmwareErrorModel
    {
        public string errorMessage { get; set; }
    }
    public class FirmwareUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Message { get; set; }
    
        [Required]
        [Editable(true)]
        public string FirmwareName { get; set; }
    }
}