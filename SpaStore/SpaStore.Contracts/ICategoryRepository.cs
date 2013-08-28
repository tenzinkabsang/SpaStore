using System.Collections.Generic;
using SpaStore.Model;

namespace SpaStore.Contracts
{
    public interface ICategoryRepository: IRepository<Category>
    {
        IList<string> GetCategoryNames();
    }
}