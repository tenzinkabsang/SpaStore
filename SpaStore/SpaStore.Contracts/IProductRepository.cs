using System.Collections.Generic;
using System.Linq;
using SpaStore.Model;

namespace SpaStore.Contracts
{
    public interface IProductRepository: IRepository<Product>
    {
        IList<Product> GetByCategoryId(int id);

        IQueryable<ProductBrief> GetProductBriefs();

        Product GetByIdFull(int id);
    }
}