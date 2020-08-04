using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Productcode
    {
        public Productcode()
        {
            Product = new HashSet<Product>();
            Producttypeproductcoderelationship = new HashSet<Producttypeproductcoderelationship>();
        }

        public int ProductCodeId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Producttypeproductcoderelationship> Producttypeproductcoderelationship { get; set; }
    }
}
