using System;
using System.Collections.Generic;
using System.Data.Entity;
using SpaStore.Contracts;

namespace SpaStore.Data.Helpers
{
    public class RepositoryFactories
    {
        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

        private IDictionary<Type, Func<DbContext, object>> GetRepoFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
                       {
                           { typeof(IProductRepository), context => new ProductRepository(context) },
                           { typeof(ICategoryRepository), context => new CategoryRepository(context) }
                       };
        }

        public RepositoryFactories()
        {
            _repositoryFactories = GetRepoFactories();
        }

        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        }


        public Func<DbContext, object> GetRepo<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultRepositoryFactory<T>();
        }


        private Func<DbContext, object> GetRepositoryFactory<T>()
        {
            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        private Func<DbContext, object> DefaultRepositoryFactory<T>() where T : class
        {
            return context => new SqlRepository<T>(context);
        }
    }
}