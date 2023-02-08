using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiLibro.Models;

namespace WebApiLibro.Data
{
    public class DBLibroContext:DbContext
    {
        //Contructori
        public DBLibroContext(DbContextOptions<DBLibroContext> options):base(options){ }

        //Propiedades por cada modelo --->Tabla
        public DbSet<Libro> Libros { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Editorial> Editoriales { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Persona> Personas { get; set; }



    }
}
