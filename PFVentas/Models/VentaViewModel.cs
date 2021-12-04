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
        public String CanalVta { get; set; }
        public int Cantidad { get; set; }
        public double PrecioVtaUnit { get; set; }
        public String NomProd { get; set; }
        public int CantExist { get; set; }
        public double PrecioCosto { get; set; }
    }
}
