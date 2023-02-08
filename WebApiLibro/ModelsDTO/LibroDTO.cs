using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApiLibro.Models;

namespace WebApiLibro.ModelsDTO
{
    public class LibroDTO
    {

        //convension Id o LibroId --> EF PK Identity true (autonumerico)
        public int ID { get; set; }

        //Titulo ---> null nvarchar(max) default --->No lo vamos a dejar por defecto
        [Required] //No acepta nulos
        [StringLength(50)]
        //[StringLength(50)]
        public string Titulo { get; set; }

        

        public int AutorId { get; set; }

       

    }
}
