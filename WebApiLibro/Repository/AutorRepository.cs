using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiLibro.Data;
using WebApiLibro.Models;
using WebApiLibro.ModelsDTO;

namespace WebApiLibro.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly DBLibroContext _context;

        public AutorRepository(DBLibroContext context)
        {
            this._context = context;
        }


        public bool CreateAutor(Autor autor)
        {
            bool valor = _context.Autores.Any(e => e.Nombre.ToLower().Trim() == autor.Nombre.ToLower().Trim() && e.Apellido == autor.Apellido);
            
            if (valor)
            {
                return false;
            }

            _context.Add(autor);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Autor> GetAutor()
        {
            
            return _context.Autores.ToList();
        }

        public bool UpdateAutor(int id, Autor autor)
        {
            var aut = _context.Autores.SingleOrDefault(m => m.IdAutor == id);
            if (aut == null)
            {
                return false;
            }

            
            aut.Nombre = autor.Nombre;
            aut.Apellido = autor.Apellido;
            aut.FechaNacimiento = autor.FechaNacimiento;

            _context.Update(aut);
            _context.SaveChanges();

            return true;
        }
    }
}
