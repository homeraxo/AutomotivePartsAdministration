using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Vehicleengine
    {
        public Vehicleengine()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int VehicleEngineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int EngineCylinderArrangementId { get; set; }
        public int EngineSizeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Enginecylinderarrangement EngineCylinderArrangement { get; set; }
        public virtual Enginesize EngineSize { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
