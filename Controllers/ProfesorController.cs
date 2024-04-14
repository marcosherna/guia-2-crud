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
        public async Task<ActionResult<List<Profesor>>> Get(){
            return  await this.repository.Get();
        }

        [HttpPost]
        public async Task<ActionResult<Profesor>> Add([FromBody] Profesor Profesor){
            var result = StatusCode(500);
            try { 
                Profesor _Profesor = await this.repository.Add(Profesor);
                return CreatedAtAction(nameof(GetById), new { id = _Profesor.Id }, _Profesor);
            }
            catch (System.Exception) {
                return result;
            } 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetById(int id){ 
            try {
                Profesor Profesor = await this.repository.GetById(id);
                return Profesor != null ? 
                    Profesor :  NotFound(); 
            }
            catch (System.Exception) {
                return  StatusCode(500);
            } 
        }

        [HttpDelete("{id}")] 
        public async Task<ActionResult> Delete(int id) {
            var result = StatusCode(500);
            try {
                result = await this.repository.Delete(id) ? 
                    NoContent() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }

        [HttpPut("{id}")] 
        public async Task<ActionResult> Update(int id, [FromBody] Profesor Profesor) {
            var result = StatusCode(500);
            try {
                result = await this.repository.Update(id, Profesor) ? 
                    NoContent() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }
    }
}