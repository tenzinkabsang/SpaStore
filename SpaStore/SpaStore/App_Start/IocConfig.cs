using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Ninject;
using SpaStore.Contracts;
using SpaStore.Data;
using SpaStore.Data.Helpers;
using WebApiContrib.IoC.Ninject;

namespace SpaStore.App_Start
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel();

            // bind stuff here
            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
               .InSingletonScope();

            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();

            kernel.Bind<ISpaStoreUow>().To<SpaStoreUow>();


            // WebApi dependency resolver
            config.DependencyResolver = new NinjectResolver(kernel);
        }
    }
}