using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiControlStock.Models
{
    public class Categoria
    {
        [Key]
        public int  ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }


        #region propiedades de navegación
        public List<Producto> Productos { get; set; }

        #endregion

    }
}
