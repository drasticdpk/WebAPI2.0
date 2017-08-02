using log4net;
using Microsoft.Practices.Unity;
using Remit.BusinessService;
using Remit.BusinessService.Imp;
using Remit.Data.UnitOfWork;
using System.Web.Http;
using Unity.WebApi;

namespace Remit.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            // configure logger
            log4net.Config.XmlConfigurator.Configure();
            ILog logger = LogManager.GetLogger("default");
            var container = new UnityContainer().RegisterInstance(typeof(ILog), logger); ;

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICustomerServices, CustomerServices>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}