using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleNorthwindsApi.Server.Configuration;
using SimpleNorthwindsApi.Server.DataStores;
using SimpleNorthwindsApi.Server.Services.Categories;
using SimpleNorthwindsApi.Server.Services.Customers;
using SimpleNorthwindsApi.Server.Services.Mappers;
using System.IO;

namespace SimpleNorthwindsApi.Server
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

            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<ICustomerService, CustomerService>(sp => new CustomerService(new CustomerMapper(), sp.GetRequiredService<ICustomerRepository>()));

            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<ICategoryService, CategoryService>(sp => new CategoryService(new CategoryMapper(), sp.GetRequiredService<ICategoryRepository>()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
