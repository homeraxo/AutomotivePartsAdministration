using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Productsalerelationship
    {
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public double Quantity { get; set; }
        public double SubTotal { get; set; }
        public double? Tax { get; set; }
        public double Total { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
