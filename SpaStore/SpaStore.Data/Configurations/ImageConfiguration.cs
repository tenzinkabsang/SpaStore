using System.Data.Entity.ModelConfiguration;
using SpaStore.Model;

namespace SpaStore.Data.Configurations
{
    public class ImageConfiguration : EntityTypeConfiguration<Image>
    {
        public ImageConfiguration()
        {
            Property(i => i.Id).HasColumnOrder(0);

            Property(i => i.Url)
                .IsRequired()
                .HasMaxLength(100);

            Property(i => i.Name)
                .IsOptional()
                .HasMaxLength(100);
        }
    }
}