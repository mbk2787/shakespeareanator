namespace Shakespeareanator.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Prometheus;
    using Shakespeareanator.FunTranslations;
    using Shakespeareanator.FunTranslations.Interfaces;
    using Shakespeareanator.Pokemon;
    using Shakespeareanator.Pokemon.Interfaces;
    using Shakespeareanator.Services;
    using Shakespeareanator.Services.Implementations;

    public class Startup
    {
        #region Fields

        private readonly string apiName;
        private readonly string apiVersion;

        #endregion

        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
              .AddEnvironmentVariables();

            Configuration = builder.Build();

            apiName = Configuration.GetValue<string>("api:name");
            apiVersion = Configuration.GetValue<string>("api:version");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(apiVersion, new OpenApiInfo
                {
                    Description = $"Welcome to the {apiName} API Documentation.",
                    Title = apiName,
                    Version = apiVersion
                });

                //Add document filters
                c.DocumentFilter<TagDescriptionsDocumentFilter>();
            });

            // Register services
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<IFunTranslationsService, FunTranslationsService>();
            services.AddScoped<IShakespeareanatorService, ShakespeareanatorService>();

            // Register clients
            services.AddSingleton<IPokemonClient, PokemonClient>();
            services.AddSingleton<IFunTranslationsClient, FunTranslationsClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapMetrics("/metrics");
            });

            // Swagger section
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{apiVersion}/swagger.json", apiName);
            });
        }
    }
}