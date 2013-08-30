using System.Collections.Generic;
using System.Linq;
using SpaStore.Contracts;
using SpaStore.Model;

namespace SpaStore.Controllers
{
    public class ProductBriefsController: ApiControllerBase
    {
        public ProductBriefsController(ISpaStoreUow uow)
        {
            Uow = uow;
        }

        // GET: /api/productbriefs
        public IEnumerable<ProductBrief> Get()
        {
            return Uow.Products.GetProductBriefs()
                      .OrderBy(p => p.Id);
        }
    }
}