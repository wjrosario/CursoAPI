using System.ComponentModel.DataAnnotations;

namespace WebApiLibro.ModelsDTO
{
    public 
        class LibroAddDTO
    {
        //Titulo ---> null nvarchar(max) default --->No lo vamos a dejar por defecto
        [Required] //No acepta nulos
        [StringLength(50)]
        //[StringLength(50)]
        public string Titulo { get; set; }



        public int AutorId { get; set; }
    }
}
