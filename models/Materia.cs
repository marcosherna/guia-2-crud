using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace guia_2.models
{
    public class Materia : Entity{
        
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(length:15, ErrorMessage = "Solo admite un numero maximo de caracteres de 15")]
        public string Nombre { get; set; } = "";
    }
}