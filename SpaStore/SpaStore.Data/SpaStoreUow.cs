using System;
using SpaStore.Contracts;
using SpaStore.Data.Helpers;
using SpaStore.Model;

namespace SpaStore.Data
{
    public class SpaStoreUow : ISpaStoreUow, IDisposable 
    {
        public SpaStoreUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();
            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        protected void CreateDbContext()
        {
            DbContext = new EfDbContext();

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're ot being that careful
        }

        private EfDbContext DbContext { get; set; }

        public IRepositoryProvider RepositoryProvider { get; set; }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public IProductRepository Products 
        {
            get { return GetRepo<IProductRepository>(); }
        }

        public ICategoryRepository Categories
        {
            get { return GetRepo<ICategoryRepository>(); }
        }

        public IRepository<Image> Images
        {
            get { return GetStandardRepo<Image>(); }
        }

        // public IPersonRepository Persons { get { return GetRepo<IPersonRepository>(); } }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepo<IRepository<T>>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepo<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                if(DbContext != null)
                    DbContext.Dispose();
            }
        }
    }
}
