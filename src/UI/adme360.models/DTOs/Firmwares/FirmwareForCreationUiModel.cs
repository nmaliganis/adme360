using System.ComponentModel.DataAnnotations;

namespace adme360.models.DTOs.Firmwares
{
    public class FirmwareForCreationUiModel
    {
        [Required]
        [Editable(true)]
        public string FirmwareName { get; set; }
    }
}