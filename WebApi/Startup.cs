using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Models;
using Server.Modules;
using Services.Dependencies;
using Services.Repositories;
using Services.Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text.Json.Serialization;
using WebApi.SwaggerConfig;

namespace Server
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
            ConfigureDependencies(services);
            ConfigureDatabase(services);

            services.AddHttpContextAccessor();

            services.AddTransient<IRepoServices, RepoServices>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddControllers()
                .AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("client", new OpenApiInfo
                {
                    Title = "Client API",
                    Version = "v1",
                    Description = "API for vehicle trading app"
                });
                c.SwaggerDoc("admin", new OpenApiInfo
                {
                    Title = "Admin API",
                    Version = "v1",
                    Description = "Vehicle trading app admin API"
                });

                c.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
                {
                    Name = "Basic",
                    Description = "Please enter your username and password",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header
                });
                c.OperationFilter<AddAuthHeaderOperationFilter>();
                c.CustomOperationIds(d => (d.ActionDescriptor as ControllerActionDescriptor)?.ActionName);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
                c.EnableAnnotations();
            });
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            string connectionString;
            connectionString = Configuration.GetConnectionString("AzureDBConnectionString");
            Trace.TraceInformation(connectionString);

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "Connection string not found");

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            }, ServiceLifetime.Transient);
        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            string carNetApiKey = Configuration["CarNetApiKey"];
            string carNetApiUrl = Configuration["CarNetApiUrl"];

            if (string.IsNullOrWhiteSpace(carNetApiKey))
                throw new ArgumentNullException(nameof(carNetApiKey), "CarNet API key not found");
            if (string.IsNullOrWhiteSpace(carNetApiUrl))
                throw new ArgumentNullException(nameof(carNetApiUrl), "CarNet API url not found");

            services.AddSingleton(x => new CarNetApiClient(carNetApiKey, carNetApiUrl, new HttpClient()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/client/swagger.json", "Client API");
                c.SwaggerEndpoint("/swagger/admin/swagger.json", "Admin API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
