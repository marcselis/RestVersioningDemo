using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VersioningDemo.Domain;
using VersioningDemoCore.Mapping;
using VersioningDemoCore.V1.Mapping;
using VersioningDemoCore.V2.Mapping;

namespace VersioningDemoCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.Conventions.Add(new VersionByNamespaceConvention());
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader(),
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader
                    {
                        HeaderNames = {"api-version"}
                    });
            });
            services.AddSingleton<IMapper<Concern, V1.Models.Concern>>(svc => new ConcernToV1Mapper());
            services.AddSingleton<IMapper<V1.Models.Concern, Concern>>(svc => new V1ToConcernMapper());
            services.AddSingleton<IMapper<Concern, V2.Models.Concern>>(svc => new ConcernToV2Mapper());
            services.AddSingleton<IMapper<V2.Models.Concern, Concern>>(svc => new V2ToConcernMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
