using System.ComponentModel.DataAnnotations;

namespace webHibiscus.Models
{
    public class Servicio
    {
        [Key]
        public int id_Servicio { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public decimal precio { get; set; }
    }
}
