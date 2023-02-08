using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibro.Data;
using WebApiLibro.Models;
using WebApiLibro.ModelsDTO;
using WebApiLibro.Repository;

namespace WebApiLibro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        //Inyeccion de dependencia
        public readonly DBLibroContext context;
        public readonly IMapper mapper;
        private ILibroRepository repository;
        public LibroController(DBLibroContext context, IMapper mapper, ILibroRepository repository)
        {
            this.context = context;
            this.mapper = mapper;
            this.repository = repository;
        }
        //fin

        //GET traer/leer todos los Libros
        //get api/Libro
        [HttpGet]
        public ActionResult<IEnumerable<LibroDTO>> Get()
        {
            //var libros= context.Libros.ToList();
            //return libros; //Clase Anterior

            var listLibro = repository.GetLibros();
            var listLibroDTO = new List<LibroDTO>();

            foreach (var lista in listLibro)
            {
                listLibroDTO.Add(mapper.Map<LibroDTO>(listLibro));
            }


            return Ok(listLibroDTO);
        }

        //GET traer uno
        //GET api/Libros/3
        [HttpGet("{id}")]
        public ActionResult<Libro> GetById(int id)
        {
            Libro libro = context.Libros.Find(id);

            if (libro == null)
            {
                return NotFound();
            }
            var libroDto = mapper.Map<AutorDTO>(libro);
            return Ok(libroDto);

        }

        //POST api/libro
        [HttpPost]
        public ActionResult<Libro> Post(LibroAddDTO librodto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            ////EF inserta en la BD
            //context.Libros.Add(libro); //memoria
            //context.SaveChanges();//inserta el autor en la BD

            //return Ok(); //Clase Anterior

            if (librodto == null)
            {
                return BadRequest(ModelState);
            }

            var libro = mapper.Map<Libro>(librodto);

            if (!repository.CreateLibro(libro))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el registro {libro.ID}");
                return StatusCode(404, ModelState);
            }

            // return Ok();
            return CreatedAtRoute("GetById", routeValues: new { id = libro.ID }, value: librodto);
        }
        //PUT Actualizar 
        //PUT api/Lirbo/5
        [HttpPut("{id}")]
        public ActionResult<Libro> Put(int id, LibroModDTO libroupdate)
        {
            //if (id != libro.ID)
            //{
            //    return BadRequest();
            //}
            //context.Entry(libro).State = EntityState.Modified;
            //context.SaveChanges();

            //return Ok(); //Clase Anterior

            if (libroupdate == null || id != libroupdate.ID)
            {
                return BadRequest(ModelState);
            }


            var libro = mapper.Map<Libro>(libroupdate);

            if (!repository.UpdateLibro(id, libro))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el registro {libro.ID}");
                return StatusCode(500, ModelState);
            }

            return StatusCode(204);
        }

        //DELETE Eliminar un Lirbo por ID
        //DELETE api/libro/5
        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id)
        {
            var libro = context.Libros.FirstOrDefault(e => e.ID == id);

            var libro1 = (
                            from a in context.Libros
                            where a.ID == id
                            select a).SingleOrDefault();
            if (libro == null)
            {
                return NotFound();
            }

            context.Libros.Remove(libro);
            context.SaveChanges();

            return libro;
        }

    }
}
