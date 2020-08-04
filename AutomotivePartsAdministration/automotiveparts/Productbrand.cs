using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Productbrand
    {
        public Productbrand()
        {
            Product = new HashSet<Product>();
            Producttypeproductbrandrelationship = new HashSet<Producttypeproductbrandrelationship>();
        }

        public int ProductBrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Link { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Producttypeproductbrandrelationship> Producttypeproductbrandrelationship { get; set; }
    }
}
