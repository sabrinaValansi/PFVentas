using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PFVentas.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Display(Name = "Nombre y Apellido")]
        [Required(ErrorMessage = "Debe ingresar un nombre y apellido")]
        public String NomyApe { get; set; }
        [Required(ErrorMessage = "Debe ingresar un DNI")]
        [Range(1000000, 99999999, ErrorMessage = "El DNI ingresado debe estar entre 1.000.000 y 99.999.999")]
        public string Dni { get; set; }
        [Required(ErrorMessage = "Debe ingresar su email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email invalido")]
        public string Email { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }

        public String mostrarNomYApe()
        {
            return "Nombre y Apellido";
        }
    }
}
