using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Producttypeproductbrandrelationship
    {
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Productbrand ProductBrand { get; set; }
        public virtual Producttype ProductType { get; set; }
    }
}
