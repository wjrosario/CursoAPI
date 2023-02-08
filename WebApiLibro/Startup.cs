using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiLibro.Data;
using WebApiLibro.Helpers;//agregar
using WebApiLibro.Models;
using WebApiLibro.ModelsDTO;
using WebApiLibro.Repository;

namespace WebApiLibro
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
            services.AddAutoMapper(config =>
            {
                config.CreateMap<Autor, AutorDTO>();
                config.CreateMap<Libro, LibroDTO>();
                config.CreateMap<AutorAddDTO,Autor>().ReverseMap();
                config.CreateMap<AutorModDto, Autor>().ReverseMap();
                config.CreateMap<LibroAddDTO, Libro>().ReverseMap();
                

            }, typeof(Startup));


            services.AddDbContext<DBLibroContext>(options => options.UseSqlServer(Configuration.GetConnectionString("KeyDBLibros")));

            //seralizar los datos relacionados de EF
            services.AddMvc().AddNewtonsoftJson(
                     o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            //Registrar el filtro
            services.AddScoped<FiltroAccionPersonalizadoAttribute>();

            //Registrar Repositorio
            services.AddScoped<IRepositorio,MyRepoPersona>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ILibroRepository, LibroRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
