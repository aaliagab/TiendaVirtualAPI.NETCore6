using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;
using System.Globalization;
using TiendaAPI.Data;
using TiendaAPI.Data.Repository;
using TiendaAPI.Data.UoW;
using TiendaAPI.Filters;
using TiendaAPI.Middlewares;
using TiendaAPI.Services;
using TiendaAPI.Services.Impl;

namespace TiendaAPI
{
    public class Startup
    {
        // En Startup.cs
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
                          .MinimumLevel.Information()
                          .WriteTo.File("logs/apicore-.log", rollingInterval: RollingInterval.Day)
                          .CreateLogger();
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureCors();
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(ApiValidationFilterAttribute));
                config.EnableEndpointRouting = false;
            }).AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.ConfigureHsts();

            services.ConfigureDbContext(Configuration);
            services.ConfigureSwagger();
            services.ConfigurePerformance();
            services.ConfigureDetection();
            services.AddHttpContextAccessor();
            services.AddSignalR();
            services.AddHealthChecks();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProductoService, ProductoService>();
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, CoreDbContext dbContext)
        {
            //app.UseDetection();
            app.UseCors();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            if (env.IsProduction())
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "Tienda API V1");
                });
            }
            else if (env.IsDevelopment())
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tienda API V1");
                });
            }

            #region Localization

            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US")
            };
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            app.UseRequestLocalization(localizationOptions);

            var requestProvider = new RouteDataRequestCultureProvider();
            localizationOptions.RequestCultureProviders.Insert(0, requestProvider);
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            #endregion Localization

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware(typeof(ErrorWrappingMiddleware));
            app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHub<ChatHub>("/chathub");
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    ResultStatusCodes =
                    {
                        [HealthStatus.Healthy] = StatusCodes.Status200OK,
                        [HealthStatus.Degraded] = StatusCodes.Status200OK,
                        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                    }
                });
            });

        }


    }


}
