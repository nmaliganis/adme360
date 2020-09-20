using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace adme360.models.DTOs.Maps
{
    public class Geometry
    {
        [Required]
        [Editable(true)]
        public string type { get; set; }
        [Required]
        [Editable(true)]
        public List<List<double>> coordinates { get; set; }
    }
}