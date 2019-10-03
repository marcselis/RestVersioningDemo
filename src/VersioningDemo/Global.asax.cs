using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using VersioningDemo.Domain;
using VersioningDemo.Mapping;

namespace VersioningDemo
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterType<ConcernToV1Mapper>().As<IMapper<Concern, Models.V1.Concern>>().SingleInstance();
            builder.RegisterType<ConcernToV2Mapper>().As<IMapper<Concern, Models.V2.Concern>>().SingleInstance();
            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
