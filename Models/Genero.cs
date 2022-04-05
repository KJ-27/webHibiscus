using System.ComponentModel.DataAnnotations;

namespace webHibiscus.Models
{
    public class Genero
    {
        [Key]
        public int id_Genero { get; set; }

        public string nombre { get; set; }
    }
}
