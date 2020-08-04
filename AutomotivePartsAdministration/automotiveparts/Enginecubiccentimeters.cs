﻿using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Enginecubiccentimeters
    {
        public Enginecubiccentimeters()
        {
            Vehicleengine = new HashSet<Vehicleengine>();
        }

        public int EngineCubicCentimetersId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Vehicleengine> Vehicleengine { get; set; }
    }
}
