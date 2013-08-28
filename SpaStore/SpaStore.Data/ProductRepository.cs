using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SpaStore.Contracts;
using SpaStore.Model;

namespace SpaStore.Data
{
    public class ProductRepository :SqlRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context)
            : base(context)
        {

        }

        public IList<Product> GetProductsForCategoryName(string categoryName)
        {
            return base.DbSet.Include(c => c.Category)
                             .Include(c => c.Images)
                             .Where(p => categoryName == null || p.Category.Name == categoryName)
                             .ToList();
        }

        public IList<Product> GetByCategoryId(int id)
        {
            return DbSet
                .Include(p => p.Images)
                .Where(p => p.CategoryId == id)
                .ToList();
        }

        public override IQueryable<Product> GetAll()
        {
            return DbSet.Include(c => c.Category)
                        .Include(c => c.Images);
        }
    }
}
