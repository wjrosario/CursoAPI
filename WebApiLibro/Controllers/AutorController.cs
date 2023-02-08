using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApiLibro.Data;
using WebApiLibro.Models;
using WebApiLibro.Helpers;
using WebApiLibro.ModelsDTO;
using AutoMapper;
using System.Threading.Tasks;
using WebApiLibro.Repository;

namespace WebApiLibro.Controllers
{
    // api/Autor
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        //Inyeccion de dependencia
        public readonly DBLibroContext context;
        public readonly IMapper mapper;
        private IAutorRepository repository;
        public AutorController(DBLibroContext context, IMapper mapper, IAutorRepository repository)
        {
            this.context = context;
            this.mapper = mapper;
            this.repository = repository;

        }
        //fin
        //agregar filtro personalizado
        [ServiceFilter(typeof(FiltroAccionPersonalizadoAttribute))]
        //GET traer/leer todos los autories
        //get api/Autor
        [HttpGet]
        public ActionResult<ICollection<AutorDTO>> Get()
        {
            //    return context.Autores.ToList(); //Clase pasada

            //var autores = context.Autores.Include(x=>x.Libros).ToList();
            //return autores; //Clase pasada



            //var autores = context.Autores.Include(x => x.Libros).ToList();
            //if(autores==null)
            //{
            //    return NotFound();
            //}
            //var autoresDTO= mapper.Map<List<AutorDTO>>(autores); //Clase pasada


            var listAutor = repository.GetAutor();
            var listAutorDTO = new List<AutorDTO>();

            foreach(var lista in listAutor)
            {
                listAutorDTO.Add(mapper.Map<AutorDTO>(lista));
            }
            

            return Ok(listAutorDTO);
        }

        //GET traer uno
        //GET api/autor/3
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult <Autor> GetById(int id)
        {
            Autor autor=context.Autores.Find(id);

            if(autor == null)
            {
                return NotFound();
            }
            var autorDto = mapper.Map<AutorDTO>(autor);
            return Ok(autorDto);
            
        }

        //POST api/autor
        [HttpPost]
        public ActionResult<Autor> Post(AutorAddDTO autordto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            ////mapeo
            //var autor = mapper.Map<Autor>(autordto);

            ////EF inserta en la BD
            //context.Autores.Add(autor); //memoria
            //context.SaveChanges();//inserta el autor en la BD

            //return Ok(); //Clase anterior

            //Inicio de validaciones//
            if (autordto == null)
            {
                return BadRequest(ModelState);
            }

            var autor = mapper.Map<Autor>(autordto);

            if(!repository.CreateAutor(autor))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el registro {autor.Nombre}");
                return StatusCode(404, ModelState);
            }

           // return Ok();
            return CreatedAtRoute("GetById", routeValues:  new { id= autor.IdAutor }, value: autordto);
        }
        //PUT Actualizar 
        //PUT api/Autor/5
        //[HttpPut("{id}")]
        //public ActionResult<Autor> Put(int id, Autor autor) 
        //{
        //    if(id!= autor.IdAutor)
        //    {
        //        return BadRequest();
        //    }
        //    context.Entry(autor).State = EntityState.Modified;
        //    context.SaveChanges();

        //    return Ok();
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, AutorModDto autorUpdate)
        {
            //var autor = mapper.Map<Autor>(autorUpdate);
            //autor.IdAutor = id;

            //context.Entry(autor).State = EntityState.Modified;

            //await context.SaveChangesAsync();

            //return NoContent(); /Calse anterior

            if (autorUpdate == null || id != autorUpdate.IdAutor)
            {
                return BadRequest(ModelState);
            }


            var autor = mapper.Map<Autor>(autorUpdate);
            
            if (!repository.UpdateAutor(id, autor))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el registro {autor.IdAutor}");
                return StatusCode(500, ModelState);
            }

            return StatusCode(204);

        }

        //DELETE Eliminar un autori por ID
        //DELETE api/autor/5
        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete (int id)
        {
            var autor = context.Autores.FirstOrDefault(e => e.IdAutor == id);

            var autor1 = (
                            from a in context.Autores
                            where a.IdAutor == id
                            select a).SingleOrDefault();
            if (autor==null)
            {
                return NotFound();
            }

            context.Autores.Remove(autor);
            context.SaveChanges();

            return autor;
        }

    }
}
