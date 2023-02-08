using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using WebApiLibro.Helpers;
using WebApiLibro.Models;

namespace WebApiLibro.ModelsDTO
{
    public class AutorDTO
    {
        
        public int IdAutor { get; set; }

        [PrimeraLetraMayuscula]
        [Required(ErrorMessage = "Nombre es obligatorio")]
        public string Nombre { get; set; }

        [PrimeraLetraMayuscula]
        [StringLength(50)]
        [Required(ErrorMessage = "Apellido es obligatorio")]

        public string Apellido { get; set; }
        //al agregar el simbolo ? al final del tipo de dato.Estaria extendido y va ahacer un tipo Nulable

        public DateTime? FechaNacimiento { get; set; }


        public List<LibroDTO> Libros { get; set; }



    }
}
