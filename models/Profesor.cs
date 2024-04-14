using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks; 
using System.ComponentModel.DataAnnotations;

namespace guia_2.models
{
    public class Profesor: Entity{

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(length: 50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(length: 50, ErrorMessage = "Maximo 50 caracteres")]
        public string Apellido { get; set; }= ""; 

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(length: 254, ErrorMessage = "Maximo 254 caracteres")]
        public string Email { get; set; } = ""; 
    }
}