using System.Collections.Generic;
using System.Linq;
using SpaStore.Contracts;
using SpaStore.Model;

namespace SpaStore.Controllers
{
    public class CategoryBriefsController: ApiControllerBase
    {
        public CategoryBriefsController(ISpaStoreUow uow)
        {
            Uow = uow;
        }

        // GET: /api/categorybriefs
        public IEnumerable<CategoryBrief> Get()
        {
            return Uow.Categories.GetCategoryBriefs()
                      .OrderBy(c => c.Name);
        }
    }
}