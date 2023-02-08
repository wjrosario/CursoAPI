using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using WebApiLibro.Helpers;
using WebApiLibro.Models;

namespace WebApiLibro.ModelsDTO
{
    public class AutorAddDTO
    {

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }


        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
        //al agregar el simbolo ? al final del tipo de dato.Estaria extendido y va ahacer un tipo Nulable

        public DateTime? FechaNacimiento { get; set; }
    }
}
