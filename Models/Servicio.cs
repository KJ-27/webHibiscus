using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webHibiscus.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            Reservas = new HashSet<Reserva>();
        }
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
