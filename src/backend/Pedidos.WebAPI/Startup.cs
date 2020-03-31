using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pedidos.Domain.LojaContexto.Handlers;
using Pedidos.Domain.LojaContexto.Repositorios;
using Pedidos.Infra.LojaContexto.DataContexts;
using Pedidos.Infra.LojaContexto.Repositorios;
using Pedidos.Shared;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Pedidos.WebAPI
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddResponseCompression();
            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            services.AddTransient<IPedidoRepositorio, PedidoRepositorio>();
            services.AddTransient<PedidoHandler, PedidoHandler>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Fast Shop Store", Version = "v1" });
            });

            Settings.ConnectionStringMySql = $"{Configuration["ConnectionStringMySql"]}";
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options => options.WithOrigins("http://localhost:4200").WithOrigins("https://localhost:5001").AllowAnyMethod()
                );

            app.UseMvc();

            app.UseResponseCompression();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fast Shop Store - V1");
            });
        }
    }
}
