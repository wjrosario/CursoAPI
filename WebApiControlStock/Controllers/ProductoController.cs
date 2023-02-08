using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiControlStock.Data;
using WebApiControlStock.Helpers;
using WebApiControlStock.Models;

namespace WebApiControlStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        //Inyeccion de dependencia
        public readonly DBStockContext context;
        public ProductoController(DBStockContext context)
        {
            this.context = context;
        }
        //fin

        //agregar filtro personalizado
        [ServiceFilter(typeof(FiltroAccionPersonalizadoAttribute))]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            //    return context.Categoria.ToList(); //Clase pasada

            var productos = context.Productos.Include(x => x.Categoria).ToList();
            return productos;
        }

        //GET traer uno
        //GET api/Producto/3
        //agregar filtro personalizado
        [ServiceFilter(typeof(FiltroAccionPersonalizadoAttribute))]
        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            Producto producto = context.Productos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;

        }

        //POST api/autor
        [HttpPost]
        public ActionResult<Producto> Post(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //EF inserta en la BD
            context.Productos.Add(producto); //memoria
            context.SaveChanges();//inserta el autor en la BD

            return Ok();
        }

    }
}
