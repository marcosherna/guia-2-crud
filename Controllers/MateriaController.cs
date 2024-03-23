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
    public class MateriaController : ControllerBase {     
        private readonly IRepository<Materia> repository;

        public MateriaController(IRepository<Materia> repository) {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Materia>> Get(){
            return this.repository.Get();
        }

        [HttpPost]
        public ActionResult Add([FromBody] Materia materia){
            var result = StatusCode(500);
            try {
                result = this.repository.Add(materia) ? 
                    Ok() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<Materia> GetById(string id){ 
            try {
                Materia materia = this.repository.GetById(id);
                return materia != null ? 
                    materia :  NotFound(); 
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
        public ActionResult Update(string id, [FromBody] Materia materia) {
            var result = StatusCode(500);
            try {
                result = this.repository.Update(id, materia) ? 
                    NoContent() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }
    }
}