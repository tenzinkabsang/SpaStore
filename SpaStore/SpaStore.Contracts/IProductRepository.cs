using System.Collections.Generic;
using SpaStore.Model;

namespace SpaStore.Contracts
{
    public interface IProductRepository: IRepository<Product>
    {
        IList<Product> GetProductsForCategoryName(string categoryName);
        IList<Product> GetByCategoryId(int id);
    }
}