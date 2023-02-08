using System.Collections.Generic;
using WebApiLibro.Models;

namespace WebApiLibro.Repository
{
    public interface ILibroRepository
    {

        IEnumerable<Libro> GetLibros();
        bool CreateLibro(Libro libro);
        bool UpdateLibro(int id, Libro libro);

    }
}
