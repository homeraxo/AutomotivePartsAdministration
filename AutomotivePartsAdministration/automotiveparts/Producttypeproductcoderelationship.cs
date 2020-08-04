using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Producttypeproductcoderelationship
    {
        public int ProductTypeId { get; set; }
        public int ProductCodeId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Productcode ProductCode { get; set; }
        public virtual Producttype ProductType { get; set; }
    }
}
