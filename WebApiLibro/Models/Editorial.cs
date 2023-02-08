using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibro.Models
{
    [Table("Editorial")]
    public class Editorial
    {
        [Key]
        public int IdEditorial { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Direccion { get; set; }

        public DateTime FechaInicioActividades { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Ciudad { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Pais { get; set; }

        #region propiedades de navegación
        public List<Libro> Libros { get; set; }

        public List<Empleado> Empleado { get; set; }

        #endregion


    }
}
