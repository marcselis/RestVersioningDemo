using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace VersioningDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            //services.AddSwaggerGen();
            //services.AddSingleton<IMapper<Concern, V1.Models.Concern>>(svc => new ConcernToV1Mapper());
            //services.AddSingleton<IMapper<V1.Models.Concern, Concern>>(svc => new V1ToConcernMapper());
            //services.AddSingleton<IMapper<Concern, V2.Models.Concern>>(svc => new ConcernToV2Mapper());
            //services.AddSingleton<IMapper<V2.Models.Concern, Concern>>(svc => new V2ToConcernMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
