using SpaStore.Model;

namespace SpaStore.Contracts
{
    public interface ISpaStoreUow
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        IProductRepository Products { get; }

        ICategoryRepository Categories { get; }

        IRepository<Image> Images { get; } 
    }
}