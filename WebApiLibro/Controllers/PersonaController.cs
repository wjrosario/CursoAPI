using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiLibro.Models;
using WebApiLibro.Repository;
namespace WebApiLibro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private IRepositorio _repository;

        public PersonaController(IRepositorio repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            var list = _repository.GetPeople();
            return list;
        }

        [HttpPost]
        public IActionResult Create()
        {
            _repository.CreatePerson();
            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult Edit(int id)
        {
            _repository.UpdatePerson(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.DeletePerson(id);
            return Ok();
        }

    }
}
