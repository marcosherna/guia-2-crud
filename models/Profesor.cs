using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using System.ComponentModel.DataAnnotations;

namespace guia_2.models
{
    public class Profesor: Entity{
        
        [Required(ErrorMessage = "El campo es requerido")]  
        [MaxLength(length: 20, ErrorMessage = "El campos solo admite un numero maximo de caracteres de 20")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "El campo es requerido")]  
        [MaxLength(length: 20, ErrorMessage = "El campos solo admite un numero maximo de caracteres de 20")]
        public string Apellido { get; set; }= ""; 

        [Required(ErrorMessage = "El campo es requerido")]  
        [EmailAddress(ErrorMessage = "El campo debe ser valido como email")]
        public string Email { get; set; } = ""; 
    }
}