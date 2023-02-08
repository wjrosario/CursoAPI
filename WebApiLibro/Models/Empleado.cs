using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibro.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }
        public int Legajo { get; set; }

        public int EditorialId { get; set; }


        #region propiedades de navegación

        [ForeignKey("EditorialId")]
        public Editorial Editorial { get; set; }


        #endregion
    }
}
