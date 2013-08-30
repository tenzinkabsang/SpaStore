using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SpaStore.Contracts;
using SpaStore.Model;

namespace SpaStore.Data
{
    public class ProductRepository : SqlRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public IList<Product> GetByCategoryId(int id)
        {
            return DbSet
                .Include(p => p.Images)
                .Where(p => p.CategoryId == id)
                .ToList();
        }

        public IQueryable<ProductBrief> GetProductBriefs()
        {
            return DbSet.Select(p => new ProductBrief
                                         {
                                             Id = p.Id,
                                             CategoryId = p.CategoryId,
                                             Name = p.Name,
                                             Description = p.Description,
                                             Price = p.Price,
                                             PrimaryUrl = p.Images.Where(i => i.IsPrimary).Select(i => i.Url).FirstOrDefault()
                                         });
        }

        public Product GetByIdFull(int id)
        {
            return DbSet.Include(p => p.Category)
                        .Include(p => p.Images)
                        .FirstOrDefault(p => p.Id == id);
        }

        public override IQueryable<Product> GetAll()
        {
            return base.GetAll()
                       .Include(p => p.Category)
                       .Include(p => p.Images);
        }
    }
}
