using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace guia_2.models
{
    public class Carrera : Entity {
        
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(length:3, ErrorMessage = "maximo 3 caracteres")]
        public string Codigo { get; set; } = "";

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(length:40, ErrorMessage = "maximo 40 caracteres")]
        public string Nombre { get; set; } = "";
    }
}