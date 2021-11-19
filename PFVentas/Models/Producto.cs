using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PFVentas.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        [Display(Name = "Producto")]
        [Required(ErrorMessage = "Debe ingresar producto a agregar")]
        public String NomProd { get; set; }
        [Display(Name = "Cantidad existente")]
        [Required(ErrorMessage = "Debe ingresar la cantidad existente del producto")]
        [Range(1, 100, ErrorMessage = "La cantidad deber estar entre 1 y 100")]
        public int CantExist { get; set; }
        [Display(Name = "Precio de costo")]
        [Required(ErrorMessage = "Debe ingresar el precio de costo del producto")]
        [Range(1, 10000,ErrorMessage = "El precio deber estar entre $1 y $10000")]
        public double PrecioCosto { get; set; }
    }
}
