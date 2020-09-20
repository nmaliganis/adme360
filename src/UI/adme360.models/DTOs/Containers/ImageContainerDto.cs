using System.ComponentModel.DataAnnotations;

namespace adme360.models.DTOs.Containers
{
    public class ImageContainerDto
    {
        [Required] public bool IsStoredSuccessfully { get; set; }

        [Required] public string Path { get; set; }
        [Required] public string Message { get; set; }
    }
}