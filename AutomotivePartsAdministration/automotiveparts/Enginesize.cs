using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Enginesize
    {
        public Enginesize()
        {
            Vehicleengine = new HashSet<Vehicleengine>();
        }

        public int EngineSizeId { get; set; }
        public string Liter { get; set; }
        public string CubicCentimeters { get; set; }
        public string CubicInches { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Vehicleengine> Vehicleengine { get; set; }
    }
}
