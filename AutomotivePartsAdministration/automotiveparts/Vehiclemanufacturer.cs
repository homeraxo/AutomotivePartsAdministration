using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Vehiclemanufacturer
    {
        public Vehiclemanufacturer()
        {
            Vehicle = new HashSet<Vehicle>();
            Vehiclecategorymanufacturerrelationship = new HashSet<Vehiclecategorymanufacturerrelationship>();
            Vehiclemodel = new HashSet<Vehiclemodel>();
        }

        public int VehicleManufacturerId { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Link { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
        public virtual ICollection<Vehiclecategorymanufacturerrelationship> Vehiclecategorymanufacturerrelationship { get; set; }
        public virtual ICollection<Vehiclemodel> Vehiclemodel { get; set; }
    }
}
