using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SpaStore.Data.Helpers
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly RepositoryFactories _repoFactories;

        public RepositoryProvider(RepositoryFactories repoFactories)
        {
            _repoFactories = repoFactories;
            Repositories = new Dictionary<Type, object>();
        }

        protected Dictionary<Type, object> Repositories { get; private set; }

        public DbContext DbContext { get; set; }
        
        public T GetRepo<T>() where T : class
        {
            // Look for T dictionary cache under typeof(T)
            object repoObj;
            if (Repositories.TryGetValue(typeof(T), out repoObj))
                return (T)repoObj;

            return MakeRepository<T>(DbContext);
        }

        public void SetRepository<T>(T repository)
        {
            Repositories[typeof(T)] = repository;
        }


        // helpers
        protected virtual T MakeRepository<T>(DbContext dbContext) where T: class 
        {
            Func<DbContext, object> f = _repoFactories.GetRepo<T>();
            if(f == null)
                throw new NotImplementedException("No factory for repository type, " + typeof(T).FullName);

            T repo = (T)f(dbContext);
            Repositories[typeof(T)] = repo;
            return repo;
        }
    }
}