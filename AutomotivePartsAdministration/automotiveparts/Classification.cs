using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Classification
    {
        public Classification()
        {
            Category = new HashSet<Category>();
        }

        public int ClassificationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public bool? IsActive { get; set; }
        public int ProductTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Producttype ProductType { get; set; }
        public virtual ICollection<Category> Category { get; set; }
    }
}
