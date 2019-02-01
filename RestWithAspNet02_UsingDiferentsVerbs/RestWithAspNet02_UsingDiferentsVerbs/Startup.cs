 using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestWithAspNet02_UsingDiferentsVerbs.Services;
using RestWithAspNet02_UsingDiferentsVerbs.Services.Implematattions;

namespace RestWithAspNet02_UsingDiferentsVerbs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["MySqlConnection:MySqlConnectionString"];

            services.AddDbContext<Model.Context.MySQLContext>(options => options.UseMySql(connection));

            // add framework services
            services.AddMvc();
            // Dependency Injection
            services.AddScoped<IPersonService, PersonServiceImpl>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
