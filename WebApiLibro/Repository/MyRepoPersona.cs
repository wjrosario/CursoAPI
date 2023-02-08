using System;
using System.Collections.Generic;
using System.Linq;
using WebApiLibro.Data;
using WebApiLibro.Models;

namespace WebApiLibro.Repository
{
    public class MyRepoPersona : IRepositorio
    {
        private readonly DBLibroContext _context;

        public MyRepoPersona(DBLibroContext context)
        {
            this._context = context;
        }

        public IEnumerable<Persona> GetPeople()
        {
            return _context.Personas.ToList();
        }

        public void CreatePerson()
        {
            _context.Add(new Persona() { FirstName = "Robert ", LastName = "Berends", City = "Birmingham", Address = "2632 Petunia Way" });
            _context.SaveChanges();
        }

        public void UpdatePerson(int id)
        {
            var person = _context.Personas.SingleOrDefault(m => m.PersonId == id);
            person.FirstName = "Brandon";
            _context.Update(person);
            _context.SaveChanges();
        }

        public void DeletePerson(int id)
        {
            var person = _context.Personas.SingleOrDefault(m => m.PersonId == id);
            _context.Personas.Remove(person);
            _context.SaveChanges();
        }

    }
}
