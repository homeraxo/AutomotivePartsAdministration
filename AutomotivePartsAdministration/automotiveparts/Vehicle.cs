using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Productvehiclerelationship = new HashSet<Productvehiclerelationship>();
            Vehicleservice = new HashSet<Vehicleservice>();
        }

        public int VehicleId { get; set; }
        public string Version { get; set; }
        public string Cylinders { get; set; }
        public int BeginYear { get; set; }
        public int EndYear { get; set; }
        public string EngineOilCapacity { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Link { get; set; }
        public string SearchVehicle { get; set; }
        public bool? IsActive { get; set; }
        public int VehicleManufacturerId { get; set; }
        public int VehicleModelId { get; set; }
        public int VehicleCategoryId { get; set; }
        public int? VehicleEngineId { get; set; }
        public int? VehicleTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Vehiclecategory VehicleCategory { get; set; }
        public virtual Vehicleengine VehicleEngine { get; set; }
        public virtual Vehiclemanufacturer VehicleManufacturer { get; set; }
        public virtual Vehiclemodel VehicleModel { get; set; }
        public virtual Vehicletype VehicleType { get; set; }
        public virtual ICollection<Productvehiclerelationship> Productvehiclerelationship { get; set; }
        public virtual ICollection<Vehicleservice> Vehicleservice { get; set; }
    }
}
