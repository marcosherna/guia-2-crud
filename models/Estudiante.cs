using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace guia_2.models
{
    public class Estudiante : Entity{
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(length:50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(length:50, ErrorMessage = "Maximo 50 caracteres")]
        public string Apellido { get; set; } = "";

        [Required(ErrorMessage = "El campo es requerido")]
        [MinLength(length:12, ErrorMessage = "Minimo 12 caracteres")]
        [MaxLength(length:50, ErrorMessage = "Maximo 50 caracteres")]
        public string Codigo { get; set; } = "";

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(length:254, ErrorMessage = "Maximo 254 caracteres")]
        [EmailAddress(ErrorMessage = "El formato de correo electronico no es valido")]
        public string Correo { get; set; } = "";
    }
}