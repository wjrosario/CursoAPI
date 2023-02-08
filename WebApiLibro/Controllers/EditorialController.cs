using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibro.Data;
using WebApiLibro.Models;

namespace WebApiLibro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
       
        //Inyeccion de dependencia
        public readonly DBLibroContext context;
        public EditorialController(DBLibroContext context)
        {
            this.context = context;
        }
        //fin

        //GET traer/leer todos las Editoriales
        //get api/Editorial
        [HttpGet]
        public ActionResult<IEnumerable<Editorial>> Get()
        {
            return context.Editoriales.ToList();
        }

        //GET traer uno
        //GET api/Editorial/3
        [HttpGet("{id}")]
        public ActionResult <Editorial> GetById(int id)
        {
            Editorial editorial = context.Editoriales.Find(id);

            if(editorial == null)
            {
                return NotFound();
            }
             
            return editorial;
            
        }

        //POST api/editorial
        [HttpPost]
        public ActionResult<Editorial> Post(Editorial editorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //EF inserta en la BD
            context.Editoriales.Add(editorial); //memoria
            context.SaveChanges();//inserta el autor en la BD

            return Ok();
        }
        //PUT Actualizar 
        //PUT api/editorial/5
        [HttpPut("{id}")]
        public ActionResult<Editorial> Put(int id, Editorial editorial) 
        {
            if(id!= editorial.IdEditorial)
            {
                return BadRequest();
            }
            context.Entry(editorial).State = EntityState.Modified;
            context.SaveChanges();
            
            return Ok();
        }

        //DELETE Eliminar un autori por ID
        //DELETE api/autor/5
        [HttpDelete("{id}")]
        public ActionResult<Editorial> Delete (int id)
        {
            var editorial = context.Editoriales.FirstOrDefault(e => e.IdEditorial == id);

            var editorial1 = (
                            from a in context.Autores
                            where a.IdAutor == id
                            select a).SingleOrDefault();
            if (editorial == null)
            {
                return NotFound();
            }

            context.Editoriales.Remove(editorial);
            context.SaveChanges();

            return editorial;
        }

    
    }
}
