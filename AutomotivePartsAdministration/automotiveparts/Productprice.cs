using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Productprice
    {
        public Productprice()
        {
            Historicalprice = new HashSet<Historicalprice>();
        }

        public int ProductPriceId { get; set; }
        public double Margin { get; set; }
        public double Price { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public int PriceTypeId { get; set; }
        public int ProductId { get; set; }

        public virtual Pricetype PriceType { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Historicalprice> Historicalprice { get; set; }
    }
}
