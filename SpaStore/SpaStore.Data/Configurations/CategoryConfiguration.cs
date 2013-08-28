using System.Data.Entity.ModelConfiguration;
using SpaStore.Model;

namespace SpaStore.Data.Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()         {
            Property(c => c.Id).HasColumnOrder(0);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.CreatedDate)
                .IsRequired().HasColumnType("datetime");

            Property(c => c.ModifiedDate)
                .IsRequired().HasColumnType("datetime");
        }
    }
}
