using System.Collections.Generic;
using System.Linq;
using SpaStore.Model;

namespace SpaStore.Contracts
{
    public interface ICategoryRepository: IRepository<Category>
    {
        IQueryable<CategoryBrief> GetCategoryBriefs();
    }
}