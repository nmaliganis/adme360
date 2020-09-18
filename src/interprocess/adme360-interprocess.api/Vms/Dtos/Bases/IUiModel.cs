using System;
using System.ComponentModel.DataAnnotations;

namespace magic.button.collector.api.Vms.Dtos.Bases
{
    public interface IUiModel
    {
        [Key]
        Guid Id { get; set; }
        [Editable(false)]
        string Message { get; set; }
    }
}
