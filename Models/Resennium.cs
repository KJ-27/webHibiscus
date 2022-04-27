using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webHibiscus.Models
{
    public partial class Resennium
    {
        public int IdResenia { get; set; }
        public string Cotenido { get; set; }
        public int IdCliente { get; set; }
        public int Puntuacion { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        //public object IdServicioNavigation { get; set; }
    }
}
