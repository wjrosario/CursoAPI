using System.Collections.Generic;
using System;
using WebApiLibro.Models;

namespace WebApiLibro.Repository
{
    public interface IRepositorio
    {
        IEnumerable<Persona> GetPeople();
        void CreatePerson();
        void UpdatePerson(int id);
        void DeletePerson(int id);

    }
}
