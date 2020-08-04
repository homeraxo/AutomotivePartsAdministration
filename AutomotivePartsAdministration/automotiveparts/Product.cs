using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Product
    {
        public Product()
        {
            Productcategoryrelationship = new HashSet<Productcategoryrelationship>();
            Productprice = new HashSet<Productprice>();
            Productsalerelationship = new HashSet<Productsalerelationship>();
            Productvehiclecategoryrelationship = new HashSet<Productvehiclecategoryrelationship>();
            Productvehiclerelationship = new HashSet<Productvehiclerelationship>();
        }

        public int ProductId { get; set; }
        public string PartNumber { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public string Specifications { get; set; }
        public double Cost { get; set; }
        public int Stock { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public string ImagePath { get; set; }
        public string Link { get; set; }
        public string SearchProduct { get; set; }
        public bool? IsActive { get; set; }
        public string ProductCodeName { get; set; }
        public int? ProductCodeId { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductPresentationId { get; set; }
        public int ProductBrandId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Productbrand ProductBrand { get; set; }
        public virtual Productcode ProductCode { get; set; }
        public virtual Productpresentation ProductPresentation { get; set; }
        public virtual Producttype ProductType { get; set; }
        public virtual ICollection<Productcategoryrelationship> Productcategoryrelationship { get; set; }
        public virtual ICollection<Productprice> Productprice { get; set; }
        public virtual ICollection<Productsalerelationship> Productsalerelationship { get; set; }
        public virtual ICollection<Productvehiclecategoryrelationship> Productvehiclecategoryrelationship { get; set; }
        public virtual ICollection<Productvehiclerelationship> Productvehiclerelationship { get; set; }
    }
}
