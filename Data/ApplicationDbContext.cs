using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using webHibiscus.Models;

namespace webHibiscus.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<webHibiscus.Models.Genero> Genero { get; set; }
        public DbSet<webHibiscus.Models.Servicio> Servicio { get; set; }
    }
}
