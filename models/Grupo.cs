using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guia_2.models
{
    public class Grupo: Entity {
        public string IdCarrera { get; set; } = "";
        public string IdMateria { get; set; } ="";
        public string IdProfesor { get; set; } = "";
        public int Ciclo { get; set; } 
        public int Anio { get; set; }
    }
}