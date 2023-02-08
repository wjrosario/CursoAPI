using System.ComponentModel.DataAnnotations;

namespace WebApiLibro.Models
{
    public class Persona
    {
        [Key]
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }
        public string Address { get; set; }


    }
}
