using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Vehiclecategorymanufacturerrelationship
    {
        public int VehicleCategoryId { get; set; }
        public int VehicleManufacturerId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Vehiclecategory VehicleCategory { get; set; }
        public virtual Vehiclemanufacturer VehicleManufacturer { get; set; }
    }
}
