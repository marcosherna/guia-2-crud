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
    public class CarreraController : ControllerBase {
        private readonly IRepository<Carrera> repository;

        public CarreraController(IRepository<Carrera> repository) {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Carrera>> Get(){
            return this.repository.Get();
        }

        [HttpPost]
        public ActionResult Add([FromBody] Carrera Carrera){
            var result = StatusCode(500);
            try {
                if (!ModelState.IsValid){
                    return BadRequest(ModelState);
                }
                
                result = this.repository.Add(Carrera) ? 
                    Ok() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<Carrera> GetById(string id){ 
            try {
                Carrera Carrera = this.repository.GetById(id);
                return Carrera != null ? 
                    Carrera :  NotFound(); 
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
        public ActionResult Update(string id, [FromBody] Carrera Carrera) {
            var result = StatusCode(500);
            try {
                result = this.repository.Update(id, Carrera) ? 
                    NoContent() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }
    }
}