using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibro.Models
{
    [Table("Libro")]
    public class Libro
    {
        //convension Id o LibroId --> EF PK Identity true (autonumerico)
        public int ID { get; set; }

        //Titulo ---> null nvarchar(max) default --->No lo vamos a dejar por defecto
        [Required] //No acepta nulos
        [Column(TypeName ="varchar(50)")]
        //[StringLength(50)]
        public string Titulo { get; set; }
        
        public string Descripcion { get; set; }

        public int AutorId { get; set; }

        public int EditorialId { get; set; }


        #region propiedades de navegación
        [ForeignKey("AutorId")]
        public Autor Autor { get; set; }

        [ForeignKey("EditorialId")]
        public Editorial Editorial { get; set; }


        #endregion



    }
}
