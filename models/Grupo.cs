using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace guia_2.models
{
    public class Grupo: Entity {
        public string IdCarrera { get; set; } = "";
        public string IdMateria { get; set; } ="";
        public string IdProfesor { get; set; } = "";
        public int Ciclo { get; set; } 
        public int Anio { get; set; }   
        [JsonIgnore]
        public virtual Materia? materia { get; set; } 
        [JsonIgnore]
        public virtual Profesor? profesor {get;  set;}
    }
}