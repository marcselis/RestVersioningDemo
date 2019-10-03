using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestServiceCore.Mapping;
using RestServiceCore.V1.Mapping;
using RestServiceCore.V2.Mapping;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using VersioningDemo.Domain;

namespace RestServiceCore
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
            services.AddMvc(options => options.EnableEndpointRouting = true)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
            services.AddSingleton<IMapper<Concern, V1.Models.Concern>>(svc => new ConcernToV1Mapper());
            services.AddSingleton<IMapper<V1.Models.Concern, Concern>>(svc => new V1ToConcernMapper());
            services.AddSingleton<IMapper<Concern, V2.Models.Concern>>(svc => new ConcernToV2Mapper());
            services.AddSingleton<IMapper<V2.Models.Concern, Concern>>(svc => new V2ToConcernMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMiddleware<RequestResponseLoggingMiddleware>();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                });
        }


        public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
        {
            private readonly IApiVersionDescriptionProvider _provider;

            public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
            {
                this._provider = provider;
            }

            public void Configure(SwaggerGenOptions options)
            {
                foreach (var description in _provider.ApiVersionDescriptions)
                    options.SwaggerDoc(
                        description.GroupName,
                        new Info
                        {
                            Title = $"Sample API {description.ApiVersion}",
                            Version = description.ApiVersion.ToString()
                        });
            }
        }
    }
}