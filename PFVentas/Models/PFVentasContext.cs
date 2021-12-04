using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PFVentas.Models;

namespace PFVentas.Models
{
    public class PFVentasContext:DbContext
    {
        internal readonly object todo;

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
        public DbSet<PFVentas.Models.VentaViewModel> VentaViewModel { get; set; }

    }
}
