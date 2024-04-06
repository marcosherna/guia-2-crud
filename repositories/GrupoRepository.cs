using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using guia_2.database;
using guia_2.models;

namespace guia_2.repositories
{
    public class GrupoRepository : MemoryBaseRepository<Grupo> {
        public GrupoRepository(MemoryContext context) 
            : base(context) { 
        }

        public bool AddMateria(string idGrupo, Materia materia){ 
            Grupo grupo = base.GetById(idGrupo);
            grupo.IdMateria = materia.Id;
            
            return base.Update(grupo.Id, grupo);
        }

        public override List<Grupo> Get(){
            List<Grupo> grupos = base.Get();
            grupos.ForEach( grupo => {  
                if(grupo.IdMateria != ""){
                    grupo.materia = base.context.Get<Materia>()
                        .FirstOrDefault( materia => materia.Id == grupo.IdMateria);
                }

                if(grupo.IdProfesor != ""){
                    grupo.profesor = base.context.Get<Profesor>()
                        .FirstOrDefault(profesor => profesor.Id == grupo.IdProfesor);
                }
            });

            return grupos;
        }
 
        public override Grupo GetById(string id) {
            Grupo grupo = base.GetById(id);
            if(grupo != null) {
                if(grupo.IdMateria != ""){ 
                    grupo.materia = base.context.Get<Materia>()
                        .FirstOrDefault( materia => materia.Id == grupo.IdMateria);
                }

                if(grupo.IdProfesor != ""){
                    grupo.profesor = base.context.Get<Profesor>()
                        .FirstOrDefault(profesor => profesor.Id == grupo.IdProfesor);
                }
            }
            return grupo;
        }
    }
}