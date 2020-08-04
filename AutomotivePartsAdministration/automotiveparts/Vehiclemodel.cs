using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Vehiclemodel
    {
        public Vehiclemodel()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int VehicleModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int VehicleManufacturerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Vehiclemanufacturer VehicleManufacturer { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
