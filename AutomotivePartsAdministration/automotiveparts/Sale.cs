using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Sale
    {
        public Sale()
        {
            Productsalerelationship = new HashSet<Productsalerelationship>();
            Vehicleservice = new HashSet<Vehicleservice>();
        }

        public int SaleId { get; set; }
        public string Folio { get; set; }
        public double Quantity { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public bool? IsActive { get; set; }
        public int? PartyId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Party Party { get; set; }
        public virtual ICollection<Productsalerelationship> Productsalerelationship { get; set; }
        public virtual ICollection<Vehicleservice> Vehicleservice { get; set; }
    }
}
