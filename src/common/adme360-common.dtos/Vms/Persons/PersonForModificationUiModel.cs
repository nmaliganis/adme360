﻿using System;
using System.ComponentModel.DataAnnotations;
using adme360.common.dtos.Vms.Bases;

namespace adme360.common.dtos.Vms.Persons 
{
    public class PersonForModificationUiModel : IUiModel
    {
        [Key]
        public Guid Id { get; set; }
        [Editable(true)]
        public string Message { get; set; }

        [Editable(true)]
        public string PersonFirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string PersonLastName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string PersonEmail { get; set; }
    }
}
