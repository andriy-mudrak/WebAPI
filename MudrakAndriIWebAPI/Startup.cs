using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace MudrakAndriIWebAPI
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices( IServiceCollection services )
        {
            services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_2 );

            services.AddDbContext<MyDBContext>( options => options.UseInMemoryDatabase( databaseName: "BooksDatabase" ) );

            services.AddSwaggerGen( c =>
                 {
                     c.SwaggerDoc( "v1", new Info
                     {
                         Version = "v1.0",
                         Title = "Mudrak Andrii",
                         Description = "Web API for Book",
                     } );

                     var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                     var xmlPath = Path.Combine( AppContext.BaseDirectory, xmlFile );
                     c.IncludeXmlComments( xmlPath );
                 } );



            services.AddScoped<IInMemoryRepository, InMemoryRepository>();
            services.AddScoped<IBookService, BookService>();

        }

        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();

            app.UseSwaggerUI( c =>
            {
                c.SwaggerEndpoint( "/swagger/v1/swagger.json", "My API V1" );
                c.RoutePrefix = string.Empty;

            } );

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
