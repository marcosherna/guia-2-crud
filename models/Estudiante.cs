using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guia_2.models
{
    public class Estudiante : Entity{
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string Codigo { get; set; } = "";
        public string Correo { get; set; } = "";
    }
}