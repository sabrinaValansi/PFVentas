using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PFVentas.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        [Required(ErrorMessage = "Debe ingresar la fecha de venta")]
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        [Display(Name = "Canal de venta")]
        public String CanalVta { get; set; }
        public int ProductoId { get; set; }
        [Required(ErrorMessage = "Debe ingresar el producto vendido")]
        public String Producto { get; set; }
        [Required(ErrorMessage = "Debe ingresar la cantidad vendida")]
        [Range(1, 1000, ErrorMessage = "La cantidad vendida debe estar entre 1 y 1000")]
        public int Cantidad { get; set; }
        [Display(Name = "Precio unitario")]
        [Required(ErrorMessage = "Debe ingresar el precio unitario del producto vendido")]
        [Range(1, 100000, ErrorMessage = "El precio de venta debe estar entre  $1 y $100000")]
        public double PrecioVtaUnit { get; set; }
    }
}
