using System;
using System.ComponentModel.DataAnnotations;
using adme360.models.DTOs.Base;

namespace adme360.models.DTOs.Vehicles
{
    public class VehicleUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }

        [Editable(false)]
        public string Message { get; set; }

        [Editable(false)]
        public string VehicleValue => $"{VehicleBrand} -- {VehicleNumPlate}";

        [Editable(true)]
        public string VehicleBrand { get; set; }
        [Editable(true)]
        public string VehicleNumPlate { get; set; }
        [Editable(true)]
        public bool VehicleActive { get; set; }
        [Editable(true)]
        public string VehicleType { get; set; }
        [Editable(true)]
        public string VehicleStatus { get; set; }
        [Editable(true)]
        public DateTime VehicleRegisteredDate{ get; set; }
        [Editable(true)]
        public string VehicleGas { get; set; }

    }
}