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

        [Required(ErrorMessage = "El campo es requerido")]
        public string IdCarrera { get; set; } = "";

        [Required(ErrorMessage = "El campo es requerido")]
        public string IdMateria { get; set; } ="";

        [Required(ErrorMessage = "El campo es requerido")]
        public string IdProfesor { get; set; } = "";
        
        [Required(ErrorMessage = "El campo es requerido")]
        public int Ciclo { get; set; } 

         [Required(ErrorMessage = "El campo es requerido")]
        public int Anio { get; set; }   
        [JsonIgnore]
        public virtual Materia? materia { get; set; } 
        [JsonIgnore]
        public virtual Profesor? profesor {get;  set;}
    }
}