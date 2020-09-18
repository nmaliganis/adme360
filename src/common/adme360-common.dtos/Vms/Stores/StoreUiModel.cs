using System;
using System.ComponentModel.DataAnnotations;
using adme360.common.dtos.Vms.Bases;

namespace adme360.common.dtos.Vms.Stores
{
    public class StoreUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }
        [Editable(true)]
        public string Message { get; set; }
    }
}
