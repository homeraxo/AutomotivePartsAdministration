using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Category
    {
        public Category()
        {
            Productcategoryrelationship = new HashSet<Productcategoryrelationship>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }
        public bool? IsActive { get; set; }
        public int ClassificationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Classification Classification { get; set; }
        public virtual ICollection<Productcategoryrelationship> Productcategoryrelationship { get; set; }
    }
}
