using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PFVentas.Models
{
    public class VentaViewModel
    {
        public int VentaViewModelId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        [Display(Name = "Canal de venta")]
        public String CanalVta { get; set; }
        public int Cantidad { get; set; }
        [Display(Name = "Precio venta unitario")]
        public double PrecioVtaUnit { get; set; }
        [Display(Name = "Producto")]
        public String NomProd { get; set; }
        public int CantExist { get; set; }
        [Display(Name = "Precio total costo")]
        public double PrecioCosto { get; set; }
        [Display(Name = "Precio total venta")]
        public double PrecioTotal { get; set; }
        [Display(Name = "Margen de ganancia")]
        public double MargenGanancia { get; set; }
    }
}
