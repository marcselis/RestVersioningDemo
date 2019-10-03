using System;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Web.Http;
using Microsoft.Web.Http.Versioning;
using Microsoft.Web.Http.Versioning.Conventions;

namespace VersioningDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.AddApiVersioning(options=> {
                options.Conventions.Add(new VersionByNamespaceConvention()); 
                options.AssumeDefaultVersionWhenUnspecified=true;
                options.DefaultApiVersion=new ApiVersion(1,0);
                options.ReportApiVersions=true;
                options.ApiVersionReader =
                    ApiVersionReader.Combine(new QueryStringApiVersionReader(), new HeaderApiVersionReader());
            });
            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new {id = RouteParameter.Optional}
            //);
        }

    }

    public class GenericApiVersionReader : IApiVersionReader
    {
        public void AddParameters(IApiVersionParameterDescriptionContext context)
        {
            throw new NotImplementedException();
        }

        public string Read(HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }
    }

}
