using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SpaStore.Contracts;
using SpaStore.Model;

namespace SpaStore.Data
{
    public class CategoryRepository:SqlRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context)
            : base(context)
        {
        }

        public IList<string> GetCategoryNames()
        {
            return DbSet.Select(c => c.Name)
                        .Distinct()
                        .OrderBy(c => c)
                        .ToList();
        }
    }
}