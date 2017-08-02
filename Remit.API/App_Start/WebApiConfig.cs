using log4net;
using Microsoft.Practices.Unity;
using Remit.API.Filter;
using Remit.BusinessService;
using Remit.BusinessService.Imp;
using Remit.Data.UnitOfWork;
using System.Web.Http;
using Unity.WebApi;

namespace Remit.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
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

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            // config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Filters.Add(container.Resolve<BasicAuthenticationAttribute>());
            config.Filters.Add(container.Resolve<LoggerActionFilter>()); // register filter
            config.Filters.Add(container.Resolve<ExceptionFilter>());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}