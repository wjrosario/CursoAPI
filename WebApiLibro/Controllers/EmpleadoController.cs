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
    public class EmpleadoController : ControllerBase
    {
            //Inyeccion de dependencia
            public readonly DBLibroContext context;
            public EmpleadoController(DBLibroContext context)
            {
                this.context = context;
            }
            //fin

            //GET traer/leer todos los Empleados
            //get api/Empleado
            [HttpGet]
            public ActionResult<IEnumerable<Empleado>> Get()
            {
                return context.Empleados.ToList();
            }

            //GET traer uno
            //GET api/Empleado/3
            [HttpGet("{id}")]
            public ActionResult<Empleado> GetById(int id)
            {
                Empleado empleado = context.Empleados.Find(id);

                if (empleado == null)
                {
                    return NotFound();
                }

                return empleado;

            }

            //POST api/empleado
            [HttpPost]
            public ActionResult<Empleado> Post(Empleado empleado)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //EF inserta en la BD
                context.Empleados.Add(empleado); //memoria
                context.SaveChanges();//inserta el autor en la BD

                return Ok();
            }
            //PUT Actualizar 
            //PUT api/empleado/5
            [HttpPut("{id}")]
            public ActionResult<Empleado> Put(int id, Empleado empleado)
            {
                if (id != empleado.ID)
                {
                    return BadRequest();
                }
                context.Entry(empleado).State = EntityState.Modified;
                context.SaveChanges();

                return Ok();
            }

            //DELETE Eliminar un autori por ID
            //DELETE api/empleado/5
            [HttpDelete("{id}")]
            public ActionResult<Empleado> Delete(int id)
            {

                var empleado = context.Empleados.FirstOrDefault(e => e.ID == id);

                var empleado1 = (
                                from a in context.Empleados
                                where a.ID == id
                                select a).SingleOrDefault();

                if (empleado == null)
                {
                    return NotFound();
                }

                context.Empleados.Remove(empleado);
                context.SaveChanges();

                return empleado;
            }

        


    }
}
