using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace webHibiscus.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Resennia = new HashSet<Resennium>();
            Reservas = new HashSet<Reserva>();
        }
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Cedula { get; set; }
        public int IdGenero { get; set; }
        public string IdUsuario { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual AspNetUser IdUsuarioNavigation { get; set; }
        public virtual ICollection<Resennium> Resennia { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
