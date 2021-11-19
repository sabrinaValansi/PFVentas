using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFVentas.Models
{
    public class PFVentasContext:DbContext
    {
        public
PFVentasContext(DbContextOptions<PFVentasContext> options)
: base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder
       optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=PC_SABRINA\SQLEXPRESS;Database=PFVentas
;Trusted_Connection=True;");
        }

    }
}
