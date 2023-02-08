using System.ComponentModel.DataAnnotations;
using System;

namespace WebApiLibro.ModelsDTO
{
    public class AutorModDto
    {
        public int IdAutor { get; set; }

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
