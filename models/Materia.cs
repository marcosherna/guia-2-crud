using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace guia_2.models
{
    public class Materia : Entity{
        
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(length:50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; } = "";
    }
}