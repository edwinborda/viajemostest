using System;
using System.IO;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Viajemos.Test.Book.API.Application.Models;
using Viajemos.Test.Book.API.Application.Validators;
using Viajemos.Test.Book.API.Infraestructure;
using Viajemos.Test.Book.Infraestructure;
using Viajemos.Test.Book.Infraestructure.Interfaces;
using Viajemos.Test.Book.Infraestructure.Repositories;

namespace Viajemos.Test.Book.API
{
    public class Startup
    {
        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(opt => opt.UseSqlServer(Configuration.GetConnectionString("conn"), it => it.MigrationsAssembly("Viajemos.Test.Book.API")));

            services.AddTransient<IValidator<EditorialModel>, EditorialValidator>();
            services.AddTransient<IValidator<AuthorModel>, AuthorValidator>();
            services.AddTransient<IValidator<BookModel>, BookValidator>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IEditorialService, EditorialService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IEditorialRepository, EditorialRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddSwaggerGen(it =>
            {
                it.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Admin Services",
                        Description = " Microservices for admin",
                        Version = "v1",
                        Contact = new OpenApiContact()
                        {
                            Name = "Edwin Borda",
                            Email = "edwin.borda@outlook.com",
                            Url = new Uri("https://github.com/edwinborda")
                        }
                    }
                );
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                it.IncludeXmlComments(xmlPath);
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddMvc()
                .AddFluentValidation(config => config.ImplicitlyValidateChildProperties = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
