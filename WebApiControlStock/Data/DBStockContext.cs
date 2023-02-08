using Microsoft.EntityFrameworkCore;
using WebApiControlStock.Models;

namespace WebApiControlStock.Data
{
    public class DBStockContext: DbContext
    {

        //Contructori
        public DBStockContext(DbContextOptions<DBStockContext> options) : base(options) { }

        //Propiedades por cada modelo --->Tabla
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Producto> Productos { get; set; }



    }
}
