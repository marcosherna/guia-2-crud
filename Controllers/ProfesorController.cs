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
    public class ProfesorController : ControllerBase
    {
        private readonly IRepository<Profesor> repository;

        public ProfesorController(IRepository<Profesor> repository) {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Profesor>> Get(){
            return this.repository.Get();
        }

        [HttpPost]
        public ActionResult Add([FromBody] Profesor profesor){
            var result = StatusCode(500);
            try {
                result = this.repository.Add(profesor) ? 
                    Ok() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<Profesor> GetById(string id){ 
            try {
                Profesor profesor = this.repository.GetById(id);
                return profesor != null ? 
                    profesor :  NotFound(); 
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
        public ActionResult Update(string id, [FromBody] Profesor profesor) {
            var result = StatusCode(500);
            try {
                result = this.repository.Update(id, profesor) ? 
                    NoContent() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }
    }
}