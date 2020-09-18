using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Stores
{
    public class StoreForCreationUiModel
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string StoreName { get; set; }
    }
}
