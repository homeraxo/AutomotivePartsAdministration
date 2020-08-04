using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Vehicletype
    {
        public Vehicletype()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int VehicleTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int VehicleCategoryId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Vehiclecategory VehicleCategory { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
