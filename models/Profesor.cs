using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guia_2.models
{
    public class Profesor: Entity{
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; }= ""; 
        public string Email { get; set; } = ""; 
    }
}