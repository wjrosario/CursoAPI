using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiControlStock.Helpers;
using Xunit.Sdk;

namespace WebApiControlStock.Models
{
    public class Producto
    {

        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "char(6)")]
        //[RegularExpression(@"^[A]{3}\s+[1-100]{3}$", ErrorMessage = "Solo se permiten tres AAA y números entre 1 y 100")]
        [RegularExpression(@"^[A]{3}\d{3}$", ErrorMessage = "Solo se permiten tres AAA y números entre 1 y 100")]
        public string Codigo { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "El Maximo debe ser {1} caracter")]
        [MinLength(1, ErrorMessage = "El minimo debe ser {1} caracter")]

        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        [StringRange(AllowableValues = new[] { "H", "S" }, ErrorMessage = "Tipo de producto debe ser 'H' o 'S'.")]
        public char LineaProducto { get; set; }

        [Required]
        [Column(TypeName = "money")]        
        public decimal Precio { get; set; }

        public int CategoriaId { get; set; }


        #region propiedades de navegación
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        #endregion

    }
}
