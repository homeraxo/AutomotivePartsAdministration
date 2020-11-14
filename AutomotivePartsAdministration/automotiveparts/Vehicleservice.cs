using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Vehicleservice
    {
        public int VehicleServiceId { get; set; }
        public int VehicleId { get; set; }
        public int SaleId { get; set; }
        public string CurrentUnits { get; set; }
        public string Description { get; set; }
        public DateTime? NextServiceDate { get; set; }
        public string NextServiceUnits { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
