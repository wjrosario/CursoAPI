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
    public class CategoriaController : ControllerBase
    {

        //Inyeccion de dependencia
        public readonly DBStockContext context;
        public CategoriaController(DBStockContext context)
        {
            this.context = context;
        }
        //fin

        //agregar filtro personalizado
        [ServiceFilter(typeof(FiltroAccionPersonalizadoAttribute))]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            //return context.Categorias.ToList(); //Clase pasada

            var categoria = context.Categorias.Include(x => x.Productos).ToList();
            return categoria;
        }

        //GET traer uno
        //GET api/Categoria/3
        [HttpGet("{id}")]
        //agregar filtro personalizado
        [ServiceFilter(typeof(FiltroAccionPersonalizadoAttribute))]
        public ActionResult<Categoria> GetById(int id)
        {
            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;

        }

        //POST api/autor
        [HttpPost]
        public ActionResult<Categoria> Post(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //EF inserta en la BD
            context.Categorias.Add(categoria); //memoria
            context.SaveChanges();//inserta el autor en la BD

            return Ok();
        }
    }
}
