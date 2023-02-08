using System.Collections.Generic;
using System.Linq;
using WebApiLibro.Data;
using WebApiLibro.Models;

namespace WebApiLibro.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly DBLibroContext _context;

        public LibroRepository(DBLibroContext context)
        {
            this._context = context;
        }

        public bool CreateLibro(Libro libro)
        {
            bool valor = _context.Libros.Any(e => e.Titulo.ToLower().Trim() == libro.Titulo.ToLower().Trim());

            if (valor)
            {
                return false;
            }

            _context.Add(libro);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Libro> GetLibros()
        {
            return _context.Libros.ToList();
        }

        public bool UpdateLibro(int id, Libro libro)
        {
            var lib = _context.Libros.SingleOrDefault(m => m.ID == id);
            bool LibAutor = _context.Autores.Any(m => m.IdAutor == id);
            if (lib == null || LibAutor)
            {
                return false;
            }


            lib.Titulo = libro.Titulo;
            lib.AutorId = libro.AutorId;


            _context.Update(lib);
            _context.SaveChanges();

            return true;
        }
    }
}
