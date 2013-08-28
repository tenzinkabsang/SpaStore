using System.Data.Entity.ModelConfiguration;
using SpaStore.Model;

namespace SpaStore.Data.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.Id).HasColumnOrder(0);

            // Name is required and has a max length of 100
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);

            // Product has 1 Category, Categories have many Products
            HasRequired(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .WillCascadeOnDelete(false);

            Ignore(p => p.PrimaryUrl);

            Property(p => p.CreatedDate)
                .IsRequired().HasColumnType("datetime");

            Property(p => p.ModifiedDate)
                .IsRequired().HasColumnType("datetime");
        }
    }
}