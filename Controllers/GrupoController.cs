using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using guia_2.interfaces;
using guia_2.models;
using guia_2.repositories;
using Microsoft.AspNetCore.Mvc;

namespace guia_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrupoController : ControllerBase {
        
        private IRepository<Grupo> repository; 
        
        public GrupoController(IRepository<Grupo> repository) {
            this.repository = repository as MemoryBaseRepository<Grupo>;
        }

        [HttpGet]
        public ActionResult<List<Grupo>> Get(){
            return this.repository.Get();
        }

        [HttpPost]
        public ActionResult Add([FromBody] Grupo Grupo){
            var result = StatusCode(500);
            try {
                result = this.repository.Add(Grupo) ? 
                    Ok() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<Grupo> GetById(string id){ 
            try {
                Grupo Grupo = this.repository.GetById(id);
                return Grupo != null ? 
                    Grupo :  NotFound(); 
            }
            catch (System.Exception) {
                return  StatusCode(500);
            } 
        }

        [HttpDelete("{id}")] 
        public ActionResult Delete(string id) {
            var result = StatusCode(500);
            try {
                result = this.repository.Delete(id) ? 
                    NoContent() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }

        [HttpPut("{id}")] 
        public ActionResult Update(string id, [FromBody] Grupo Grupo) {
            var result = StatusCode(500);
            try {
                result = this.repository.Update(id, Grupo) ? 
                    NoContent() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }

        [HttpGet("{id}/Materia")] 
        public ActionResult<Materia> GetMateria(string id) {
            var result = StatusCode(500);
            try {
                Grupo grupo = this.repository.GetById(id);
                if(grupo.materia != null) {
                    return grupo.materia;
                }
            }
            catch (System.Exception) {}
            return result;
        }

        [HttpGet("{id}/Profesor")] 
        public ActionResult<Profesor> GetProfesor(string id) {
            var result = StatusCode(500);
            try {
                Grupo grupo = this.repository.GetById(id);
                if(grupo.profesor != null) {
                    return grupo.profesor;
                }
            }
            catch (System.Exception) {}
            return result;
        }
    }
}