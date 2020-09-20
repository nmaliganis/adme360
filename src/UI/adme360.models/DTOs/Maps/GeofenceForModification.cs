using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Dashboards;

namespace adme360.models.DTOs.Maps
{
    public class GeofenceForModification
    {
        [Required]
        [Editable(true)]
        public List<MapUiModel> GeofenceMapPointForModification { get; set; }
    }
}
