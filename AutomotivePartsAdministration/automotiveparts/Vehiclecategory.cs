using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Vehiclecategory
    {
        public Vehiclecategory()
        {
            Productvehiclecategoryrelationship = new HashSet<Productvehiclecategoryrelationship>();
            Vehicle = new HashSet<Vehicle>();
            Vehiclecategorymanufacturerrelationship = new HashSet<Vehiclecategorymanufacturerrelationship>();
            Vehicletype = new HashSet<Vehicletype>();
        }

        public int VehicleCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Productvehiclecategoryrelationship> Productvehiclecategoryrelationship { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
        public virtual ICollection<Vehiclecategorymanufacturerrelationship> Vehiclecategorymanufacturerrelationship { get; set; }
        public virtual ICollection<Vehicletype> Vehicletype { get; set; }
    }
}
