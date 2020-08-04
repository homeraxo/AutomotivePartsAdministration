using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class automotiveparts2Context : DbContext
    {
        public automotiveparts2Context()
        {
        }

        public automotiveparts2Context(DbContextOptions<automotiveparts2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Classification> Classification { get; set; }
        public virtual DbSet<Contacttype> Contacttype { get; set; }
        public virtual DbSet<Enginecubiccentimeters> Enginecubiccentimeters { get; set; }
        public virtual DbSet<Enginecylinderarrangement> Enginecylinderarrangement { get; set; }
        public virtual DbSet<Engineliter> Engineliter { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<Historicalprice> Historicalprice { get; set; }
        public virtual DbSet<Party> Party { get; set; }
        public virtual DbSet<Partyaddress> Partyaddress { get; set; }
        public virtual DbSet<Partycontactrelationship> Partycontactrelationship { get; set; }
        public virtual DbSet<Partyorganization> Partyorganization { get; set; }
        public virtual DbSet<Partyperson> Partyperson { get; set; }
        public virtual DbSet<Partytype> Partytype { get; set; }
        public virtual DbSet<Pricetype> Pricetype { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Productbrand> Productbrand { get; set; }
        public virtual DbSet<Productcategoryrelationship> Productcategoryrelationship { get; set; }
        public virtual DbSet<Productcode> Productcode { get; set; }
        public virtual DbSet<Productpresentation> Productpresentation { get; set; }
        public virtual DbSet<Productprice> Productprice { get; set; }
        public virtual DbSet<Productsalerelationship> Productsalerelationship { get; set; }
        public virtual DbSet<Producttype> Producttype { get; set; }
        public virtual DbSet<Producttypeproductbrandrelationship> Producttypeproductbrandrelationship { get; set; }
        public virtual DbSet<Producttypeproductcoderelationship> Producttypeproductcoderelationship { get; set; }
        public virtual DbSet<Productvehiclecategoryrelationship> Productvehiclecategoryrelationship { get; set; }
        public virtual DbSet<Productvehiclerelationship> Productvehiclerelationship { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<Vehiclecategory> Vehiclecategory { get; set; }
        public virtual DbSet<Vehiclecategorymanufacturerrelationship> Vehiclecategorymanufacturerrelationship { get; set; }
        public virtual DbSet<Vehicleengine> Vehicleengine { get; set; }
        public virtual DbSet<Vehiclemanufacturer> Vehiclemanufacturer { get; set; }
        public virtual DbSet<Vehiclemodel> Vehiclemodel { get; set; }
        public virtual DbSet<Vehicleservice> Vehicleservice { get; set; }
        public virtual DbSet<Vehicletype> Vehicletype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=toor;database=automotiveparts2", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasIndex(e => e.ClassificationId)
                    .HasName("catalogtype_catalog_fk");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.ClassificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("catalogtype_catalog_fk");
            });

            modelBuilder.Entity<Classification>(entity =>
            {
                entity.ToTable("classification");

                entity.HasIndex(e => e.ProductTypeId)
                    .HasName("producttype_catalogtype_fk");

                entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Link)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Classification)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("producttype_catalogtype_fk");
            });

            modelBuilder.Entity<Contacttype>(entity =>
            {
                entity.ToTable("contacttype");

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Enginecubiccentimeters>(entity =>
            {
                entity.ToTable("enginecubiccentimeters");

                entity.Property(e => e.EngineCubicCentimetersId).HasColumnName("EngineCubicCentimetersID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Enginecylinderarrangement>(entity =>
            {
                entity.ToTable("enginecylinderarrangement");

                entity.Property(e => e.EngineCylinderArrangementId).HasColumnName("EngineCylinderArrangementID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Engineliter>(entity =>
            {
                entity.ToTable("engineliter");

                entity.Property(e => e.EngineLiterId).HasColumnName("EngineLiterID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.ToTable("expense");

                entity.Property(e => e.ExpenseId).HasColumnName("ExpenseID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Historicalprice>(entity =>
            {
                entity.ToTable("historicalprice");

                entity.HasIndex(e => e.ProductPriceId)
                    .HasName("productprice_historicalprice_fk");

                entity.Property(e => e.HistoricalPriceId).HasColumnName("HistoricalPriceID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ProductPriceId).HasColumnName("ProductPriceID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.ProductPrice)
                    .WithMany(p => p.Historicalprice)
                    .HasForeignKey(d => d.ProductPriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productprice_historicalprice_fk");
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.ToTable("party");

                entity.HasIndex(e => e.PartyAddressId)
                    .HasName("address_party_fk");

                entity.HasIndex(e => e.PartyOrganizationId)
                    .HasName("organization_party_fk");

                entity.HasIndex(e => e.PartyPersonId)
                    .HasName("person_party_fk");

                entity.HasIndex(e => e.PartyTypeId)
                    .HasName("partytype_party_fk");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PartyAddressId).HasColumnName("PartyAddressID");

                entity.Property(e => e.PartyOrganizationId).HasColumnName("PartyOrganizationID");

                entity.Property(e => e.PartyPersonId).HasColumnName("PartyPersonID");

                entity.Property(e => e.PartyTypeId).HasColumnName("PartyTypeID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.PartyAddress)
                    .WithMany(p => p.Party)
                    .HasForeignKey(d => d.PartyAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("address_party_fk");

                entity.HasOne(d => d.PartyOrganization)
                    .WithMany(p => p.Party)
                    .HasForeignKey(d => d.PartyOrganizationId)
                    .HasConstraintName("organization_party_fk");

                entity.HasOne(d => d.PartyPerson)
                    .WithMany(p => p.Party)
                    .HasForeignKey(d => d.PartyPersonId)
                    .HasConstraintName("person_party_fk");

                entity.HasOne(d => d.PartyType)
                    .WithMany(p => p.Party)
                    .HasForeignKey(d => d.PartyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("partytype_party_fk");
            });

            modelBuilder.Entity<Partyaddress>(entity =>
            {
                entity.ToTable("partyaddress");

                entity.Property(e => e.PartyAddressId).HasColumnName("PartyAddressID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NumberInside)
                    .HasColumnType("char(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NumberOutside)
                    .HasColumnType("char(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Suburb)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Partycontactrelationship>(entity =>
            {
                entity.ToTable("partycontactrelationship");

                entity.HasIndex(e => e.ContactTypeId)
                    .HasName("contacttype_partycontactrelationship_fk");

                entity.HasIndex(e => e.PartyId)
                    .HasName("party_partycontactrelationship_fk");

                entity.Property(e => e.PartyContactRelationshipId).HasColumnName("PartyContactRelationshipID");

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.Partycontactrelationship)
                    .HasForeignKey(d => d.ContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contacttype_partycontactrelationship_fk");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.Partycontactrelationship)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("party_partycontactrelationship_fk");
            });

            modelBuilder.Entity<Partyorganization>(entity =>
            {
                entity.ToTable("partyorganization");

                entity.Property(e => e.PartyOrganizationId).HasColumnName("PartyOrganizationID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Partyperson>(entity =>
            {
                entity.ToTable("partyperson");

                entity.Property(e => e.PartyPersonId).HasColumnName("PartyPersonID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MaternalSurname)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PaternalSurname)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Partytype>(entity =>
            {
                entity.ToTable("partytype");

                entity.Property(e => e.PartyTypeId).HasColumnName("PartyTypeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Pricetype>(entity =>
            {
                entity.ToTable("pricetype");

                entity.Property(e => e.PriceTypeId).HasColumnName("PriceTypeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.ProductBrandId)
                    .HasName("productbrand_product_fk");

                entity.HasIndex(e => e.ProductCodeId)
                    .HasName("productcode_product_fk");

                entity.HasIndex(e => e.ProductPresentationId)
                    .HasName("productpresentation_product_fk");

                entity.HasIndex(e => e.ProductTypeId)
                    .HasName("producttype_product_fk");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.BarCode)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(400)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImagePath)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Link)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PartNumber)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductBrandId).HasColumnName("ProductBrandID");

                entity.Property(e => e.ProductCodeId).HasColumnName("ProductCodeID");

                entity.Property(e => e.ProductCodeName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductPresentationId).HasColumnName("ProductPresentationID");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.SearchProduct)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Specifications)
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.ProductBrand)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductBrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productbrand_product_fk");

                entity.HasOne(d => d.ProductCode)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductCodeId)
                    .HasConstraintName("productcode_product_fk");

                entity.HasOne(d => d.ProductPresentation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductPresentationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productpresentation_product_fk");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("producttype_product_fk");
            });

            modelBuilder.Entity<Productbrand>(entity =>
            {
                entity.ToTable("productbrand");

                entity.Property(e => e.ProductBrandId).HasColumnName("ProductBrandID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(400)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImagePath)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Link)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Productcategoryrelationship>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CategoryId })
                    .HasName("PRIMARY");

                entity.ToTable("productcategoryrelationship");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("catalogcatalogrelationship_fk");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Productcategoryrelationship)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("catalogcatalogrelationship_fk");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productcategoryrelationship)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productcatalogrelationship_fk");
            });

            modelBuilder.Entity<Productcode>(entity =>
            {
                entity.ToTable("productcode");

                entity.Property(e => e.ProductCodeId).HasColumnName("ProductCodeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Productpresentation>(entity =>
            {
                entity.ToTable("productpresentation");

                entity.Property(e => e.ProductPresentationId).HasColumnName("ProductPresentationID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImagePath)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Productprice>(entity =>
            {
                entity.ToTable("productprice");

                entity.HasIndex(e => e.PriceTypeId)
                    .HasName("pricetype_productprice_fk");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_productprice_fk");

                entity.Property(e => e.ProductPriceId).HasColumnName("ProductPriceID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PriceTypeId).HasColumnName("PriceTypeID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.PriceType)
                    .WithMany(p => p.Productprice)
                    .HasForeignKey(d => d.PriceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pricetype_productprice_fk");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productprice)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_productprice_fk");
            });

            modelBuilder.Entity<Productsalerelationship>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.SaleId })
                    .HasName("PRIMARY");

                entity.ToTable("productsalerelationship");

                entity.HasIndex(e => e.SaleId)
                    .HasName("sale_productsalerelationship_fk");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SaleId).HasColumnName("SaleID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productsalerelationship)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_productsalerelationship_fk");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.Productsalerelationship)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sale_productsalerelationship_fk");
            });

            modelBuilder.Entity<Producttype>(entity =>
            {
                entity.ToTable("producttype");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImagePath)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Producttypeproductbrandrelationship>(entity =>
            {
                entity.HasKey(e => new { e.ProductTypeId, e.ProductBrandId })
                    .HasName("PRIMARY");

                entity.ToTable("producttypeproductbrandrelationship");

                entity.HasIndex(e => e.ProductBrandId)
                    .HasName("productbrand_producttypeproductbrandrelationship_fk");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.ProductBrandId).HasColumnName("ProductBrandID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.ProductBrand)
                    .WithMany(p => p.Producttypeproductbrandrelationship)
                    .HasForeignKey(d => d.ProductBrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productbrand_producttypeproductbrandrelationship_fk");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Producttypeproductbrandrelationship)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("producttype_producttypeproductbrandrelationship_fk");
            });

            modelBuilder.Entity<Producttypeproductcoderelationship>(entity =>
            {
                entity.HasKey(e => new { e.ProductTypeId, e.ProductCodeId })
                    .HasName("PRIMARY");

                entity.ToTable("producttypeproductcoderelationship");

                entity.HasIndex(e => e.ProductCodeId)
                    .HasName("productcode_producttypeproductcoderelationship_fk");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.ProductCodeId).HasColumnName("ProductCodeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.ProductCode)
                    .WithMany(p => p.Producttypeproductcoderelationship)
                    .HasForeignKey(d => d.ProductCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productcode_producttypeproductcoderelationship_fk");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Producttypeproductcoderelationship)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("producttype_producttypeproductcoderelationship_fk");
            });

            modelBuilder.Entity<Productvehiclecategoryrelationship>(entity =>
            {
                entity.HasKey(e => new { e.VehicleCategoryId, e.ProductId })
                    .HasName("PRIMARY");

                entity.ToTable("productvehiclecategoryrelationship");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_productvehiclecategoryrelationship_fk");

                entity.Property(e => e.VehicleCategoryId).HasColumnName("VehicleCategoryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productvehiclecategoryrelationship)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_productvehiclecategoryrelationship_fk");

                entity.HasOne(d => d.VehicleCategory)
                    .WithMany(p => p.Productvehiclecategoryrelationship)
                    .HasForeignKey(d => d.VehicleCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehiclecategory_productvehiclecategoryrelationship_fk");
            });

            modelBuilder.Entity<Productvehiclerelationship>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.VehicleId })
                    .HasName("PRIMARY");

                entity.ToTable("productvehiclerelationship");

                entity.HasIndex(e => e.VehicleId)
                    .HasName("vehicle_productvehicle_fk");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productvehiclerelationship)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_productvehicle_fk");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Productvehiclerelationship)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehicle_productvehicle_fk");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sale");

                entity.HasIndex(e => e.PartyId)
                    .HasName("party_sale_fk");

                entity.Property(e => e.SaleId).HasColumnName("SaleID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Folio)
                    .HasColumnType("char(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.PartyId)
                    .HasConstraintName("party_sale_fk");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicle");

                entity.HasIndex(e => e.VehicleCategoryId)
                    .HasName("vehiclecategory_vehicle_fk");

                entity.HasIndex(e => e.VehicleEngineId)
                    .HasName("engine_vehicle_fk");

                entity.HasIndex(e => e.VehicleManufacturerId)
                    .HasName("manufacturer_vehicle_fk");

                entity.HasIndex(e => e.VehicleModelId)
                    .HasName("model_vehicle_fk");

                entity.HasIndex(e => e.VehicleTypeId)
                    .HasName("vehicletype_vehicle_fk");

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cylinders)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EngineOilCapacity)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Link)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SearchVehicle)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.VehicleCategoryId).HasColumnName("VehicleCategoryID");

                entity.Property(e => e.VehicleEngineId).HasColumnName("VehicleEngineID");

                entity.Property(e => e.VehicleManufacturerId).HasColumnName("VehicleManufacturerID");

                entity.Property(e => e.VehicleModelId).HasColumnName("VehicleModelID");

                entity.Property(e => e.VehicleTypeId).HasColumnName("VehicleTypeID");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.VehicleCategory)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehiclecategory_vehicle_fk");

                entity.HasOne(d => d.VehicleEngine)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleEngineId)
                    .HasConstraintName("engine_vehicle_fk");

                entity.HasOne(d => d.VehicleManufacturer)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("manufacturer_vehicle_fk");

                entity.HasOne(d => d.VehicleModel)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("model_vehicle_fk");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .HasConstraintName("vehicletype_vehicle_fk");
            });

            modelBuilder.Entity<Vehiclecategory>(entity =>
            {
                entity.ToTable("vehiclecategory");

                entity.Property(e => e.VehicleCategoryId).HasColumnName("VehicleCategoryID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Vehiclecategorymanufacturerrelationship>(entity =>
            {
                entity.HasKey(e => new { e.VehicleCategoryId, e.VehicleManufacturerId })
                    .HasName("PRIMARY");

                entity.ToTable("vehiclecategorymanufacturerrelationship");

                entity.HasIndex(e => e.VehicleManufacturerId)
                    .HasName("vehiclemanufacturer_categorymanufacturerrelationship_fk");

                entity.Property(e => e.VehicleCategoryId).HasColumnName("VehicleCategoryID");

                entity.Property(e => e.VehicleManufacturerId).HasColumnName("VehicleManufacturerID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.VehicleCategory)
                    .WithMany(p => p.Vehiclecategorymanufacturerrelationship)
                    .HasForeignKey(d => d.VehicleCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehiclecategory_categorymanufacturerrelationship_fk");

                entity.HasOne(d => d.VehicleManufacturer)
                    .WithMany(p => p.Vehiclecategorymanufacturerrelationship)
                    .HasForeignKey(d => d.VehicleManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehiclemanufacturer_categorymanufacturerrelationship_fk");
            });

            modelBuilder.Entity<Vehicleengine>(entity =>
            {
                entity.ToTable("vehicleengine");

                entity.HasIndex(e => e.EngineCubicCentimetersId)
                    .HasName("cc_engine_fk");

                entity.HasIndex(e => e.EngineCylinderArrangementId)
                    .HasName("cylinderarrangement_engine_fk");

                entity.HasIndex(e => e.EngineLiterId)
                    .HasName("liter_engine_fk");

                entity.Property(e => e.VehicleEngineId).HasColumnName("VehicleEngineID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EngineCubicCentimetersId).HasColumnName("EngineCubicCentimetersID");

                entity.Property(e => e.EngineCylinderArrangementId).HasColumnName("EngineCylinderArrangementID");

                entity.Property(e => e.EngineLiterId).HasColumnName("EngineLiterID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.EngineCubicCentimeters)
                    .WithMany(p => p.Vehicleengine)
                    .HasForeignKey(d => d.EngineCubicCentimetersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cc_engine_fk");

                entity.HasOne(d => d.EngineCylinderArrangement)
                    .WithMany(p => p.Vehicleengine)
                    .HasForeignKey(d => d.EngineCylinderArrangementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cylinderarrangement_engine_fk");

                entity.HasOne(d => d.EngineLiter)
                    .WithMany(p => p.Vehicleengine)
                    .HasForeignKey(d => d.EngineLiterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("liter_engine_fk");
            });

            modelBuilder.Entity<Vehiclemanufacturer>(entity =>
            {
                entity.ToTable("vehiclemanufacturer");

                entity.Property(e => e.VehicleManufacturerId).HasColumnName("VehicleManufacturerID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImagePath)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Link)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Vehiclemodel>(entity =>
            {
                entity.ToTable("vehiclemodel");

                entity.HasIndex(e => e.VehicleManufacturerId)
                    .HasName("manufacturer_model_fk");

                entity.Property(e => e.VehicleModelId).HasColumnName("VehicleModelID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.VehicleManufacturerId).HasColumnName("VehicleManufacturerID");

                entity.HasOne(d => d.VehicleManufacturer)
                    .WithMany(p => p.Vehiclemodel)
                    .HasForeignKey(d => d.VehicleManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("manufacturer_model_fk");
            });

            modelBuilder.Entity<Vehicleservice>(entity =>
            {
                entity.HasKey(e => new { e.VehicleServiceId, e.VehicleId, e.SaleId })
                    .HasName("PRIMARY");

                entity.ToTable("vehicleservice");

                entity.HasIndex(e => e.SaleId)
                    .HasName("sale_vehicleservice_fk");

                entity.HasIndex(e => e.VehicleId)
                    .HasName("vehicle_vehicleservice_fk");

                entity.Property(e => e.VehicleServiceId)
                    .HasColumnName("VehicleServiceID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

                entity.Property(e => e.SaleId).HasColumnName("SaleID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Kilometers)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NextService)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.Vehicleservice)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sale_vehicleservice_fk");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Vehicleservice)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehicle_vehicleservice_fk");
            });

            modelBuilder.Entity<Vehicletype>(entity =>
            {
                entity.ToTable("vehicletype");

                entity.HasIndex(e => e.VehicleCategoryId)
                    .HasName("vehiclecategory_vehicletype_fk");

                entity.Property(e => e.VehicleTypeId).HasColumnName("VehicleTypeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.VehicleCategoryId).HasColumnName("VehicleCategoryID");

                entity.HasOne(d => d.VehicleCategory)
                    .WithMany(p => p.Vehicletype)
                    .HasForeignKey(d => d.VehicleCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehiclecategory_vehicletype_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
