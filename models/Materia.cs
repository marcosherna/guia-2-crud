using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using guia_2.validations;

namespace guia_2.models
{
    public class Materia : Entity{

        [Required(ErrorMessage = "El campo es requerido")]
        public string Nombre { get; set; } = "";
    }
}