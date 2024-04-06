using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using System.ComponentModel.DataAnnotations;

namespace guia_2.models
{
    public class Profesor: Entity{
        
        [Required(ErrorMessage = "El campo es requerido")]  
        [MaxLength(length: 50, ErrorMessage = "maximo 50 caracters")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "El campo es requerido")]  
        [MaxLength(length: 50, ErrorMessage = "maximo 50 caracters")]
        public string Apellido { get; set; }= ""; 

        [Required(ErrorMessage = "El campo es requerido")]  
        [EmailAddress(ErrorMessage = "El campo debe ser valido como email")]
        [MaxLength(length:254, ErrorMessage = "maximo 254 caracters")]
        public string Email { get; set; } = ""; 
    }
}