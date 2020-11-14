using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Historicalprice
    {
        public int HistoricalPriceId { get; set; }
        public double Cost { get; set; }
        public double Margin { get; set; }
        public double Price { get; set; }
        public bool? IsActive { get; set; }
        public int ProductPriceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Productprice ProductPrice { get; set; }
    }
}
