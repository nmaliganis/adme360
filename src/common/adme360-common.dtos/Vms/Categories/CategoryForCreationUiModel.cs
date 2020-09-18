using System.ComponentModel.DataAnnotations;

namespace adme360.common.dtos.Vms.Categories
{
    public class CategoryForCreationUiModel
    {
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string CategoryName { get; set; }
    }
}
