using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Viajemos.Test.Web.Infraestructure;
using Viajemos.Test.Web.Models;
using Viajemos.Test.Web.Validators;

namespace Viajemos.Test.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<BookServices>(Configuration.GetSection("bookServices"));
            services.Configure<EditorialServices>(Configuration.GetSection("editorialServices"));
            services.AddTransient<IValidator<AuthorModel>, AuthorValidator>();
            services.AddTransient<IValidator<BookModel>, BookValidator>();
            services.AddTransient<IValidator<EditorialModel>, EditorialValidator>();
            services.AddTransient(typeof(IProxy<>), typeof(Proxy<>));
            services.AddControllersWithViews().AddFluentValidation();
            services.AddWebOptimizer(cfg => {
                cfg.CompileScssFiles();
                cfg.AddScssBundle("/css/all.css", "/scss/site.scss", "/scss/form.scss");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebOptimizer();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
