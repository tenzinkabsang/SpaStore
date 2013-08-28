using System.Data.Entity;

namespace SpaStore.Data.Helpers
{
    public interface IRepositoryProvider
    {
        DbContext DbContext { get; set; }

        //IRepository<T> GetRepositoryForEntityType<T>() where T : class;

        T GetRepo<T>() where T : class;

        void SetRepository<T>(T repository);
    }
}
