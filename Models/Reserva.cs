using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webHibiscus.Models
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public DateTime FechaHora { get; set; }
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Servicio IdServicioNavigation { get; set; }
    }
}
