using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using guia_2.interfaces;
using guia_2.models;
using Microsoft.AspNetCore.Mvc;

namespace guia_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase {
        private readonly IRepository<Estudiante> repository;

        public EstudianteController(IRepository<Estudiante> repository) {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Estudiante>> Get(){
            return this.repository.Get();
        }

        [HttpPost]
        public ActionResult Add([FromBody] Estudiante Estudiante){
            var result = StatusCode(500);
            try {
                if (!ModelState.IsValid){
                    return BadRequest(ModelState);
                }
                
                result = this.repository.Add(Estudiante) ? 
                    Ok() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<Estudiante> GetById(string id){ 
            try {
                Estudiante Estudiante = this.repository.GetById(id);
                return Estudiante != null ? 
                    Estudiante :  NotFound(); 
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
        public ActionResult Update(string id, [FromBody] Estudiante Estudiante) {
            var result = StatusCode(500);
            try {
                result = this.repository.Update(id, Estudiante) ? 
                    NoContent() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }
    }
}