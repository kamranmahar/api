using api.Services;
using api.Services.DapperHelpers;
using api.Services.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySqlConnector;
using System.Data.Common;


namespace api
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:6846");
                    });
            });
            services.AddControllers();
            services.AddTransient<ICommandText, CommandText>();
            services.AddTransient<IDapperHelper, DapperHelper>();
            services.AddScoped<IProductRepository, ProductRepository>();

            //services.AddTransient<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            //  services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<DbConnection, MySqlConnection>(provider =>
            {
                return new MySqlConnection
                {
                    ConnectionString = Configuration.GetConnectionString("DefaultConnection")
                };
            });

            services.AddMvc();


            services.AddOpenApiDocument(config =>
            {
                config.Title = "ASPNET CORE 3.1/WebAPI/Dapper Async/MSSQL Prototype";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
