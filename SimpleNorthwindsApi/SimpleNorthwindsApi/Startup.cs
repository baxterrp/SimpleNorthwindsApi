using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleNorthwindsApi.Configuration;
using SimpleNorthwindsApi.DataStores;
using SimpleNorthwindsApi.Services.Customers;
using SimpleNorthwindsApi.Services.Mappers;
using System.IO;

namespace SimpleNorthwindsApi
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
            BindNorthwindsConfiguration(services);
            services.AddSingleton<ICustomerRepository, CustomerRepository>(sp => new CustomerRepository(sp.GetRequiredService<NorthwindsConfiguration>()));
            services.AddSingleton<ICustomerService, CustomerService>(sp => new CustomerService(new CustomerMapper(), sp.GetRequiredService<ICustomerRepository>()));

            services.AddControllers();
        }
        
        private void BindNorthwindsConfiguration(IServiceCollection serviceCollection)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            var appConfig = new NorthwindsConfiguration();
            config.Bind("NorthwindsConfiguration", appConfig);

            serviceCollection.AddSingleton(appConfig);
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
