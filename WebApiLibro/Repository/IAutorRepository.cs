using System.Collections.Generic;
using WebApiLibro.Models;
using WebApiLibro.ModelsDTO;

namespace WebApiLibro.Repository
{
    public interface IAutorRepository
    {
        IEnumerable<Autor> GetAutor();
        bool CreateAutor(Autor autor);
        bool UpdateAutor(int id, Autor autor);

    }
}
