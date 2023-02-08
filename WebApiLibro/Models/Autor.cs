using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//Implementacion de restricciones personalizada
using WebApiLibro.Helpers;

namespace WebApiLibro.Models
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        [PrimeraLetraMayuscula]
        [Required]
        [Column(TypeName ="varchar(50)")]
        public string Nombre { get; set; }

        [PrimeraLetraMayuscula]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }
        //al agregar el simbolo ? al final del tipo de dato.Estaria extendido y va ahacer un tipo Nulable

        public string TarjetaCredito { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        #region propiedades de navegación
        public List<Libro> Libros { get; set; }

        #endregion



    }
}
