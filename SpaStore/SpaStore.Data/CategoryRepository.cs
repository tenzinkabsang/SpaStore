using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SpaStore.Contracts;
using SpaStore.Model;

namespace SpaStore.Data
{
    public class CategoryRepository:SqlRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<CategoryBrief> GetCategoryBriefs()
        {
            return DbSet.Select(c => new CategoryBrief
                                         {
                                             Id = c.Id,
                                             Name = c.Name
                                         })
                        .Distinct();
        }
    }
}