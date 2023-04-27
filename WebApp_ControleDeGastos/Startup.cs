using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp_ControleDeGastos.Database;
using WebApp_ControleDeGastos.Repository;
using WebApp_ControleDeGastos.Repository.Interface;

namespace WebApp_ControleDeGastos
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
            services.AddControllersWithViews();

            services.AddDbContext<SistemaFinanceiroDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataBase")));

            //sempre a interface for invocada, a injesão de dependencia irá usar tudo que está presente na CategoryRepository 
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<ICard, CardRepository>();
            services.AddScoped<IExpense, ExpenseRepository>();
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IRevenue, RevenueRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
