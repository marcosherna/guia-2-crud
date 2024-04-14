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
        public async Task<ActionResult<List<Estudiante>>> Get(){
            return  await this.repository.Get();
        }

        [HttpPost]
        public async Task<ActionResult<Estudiante>> Add([FromBody] Estudiante Estudiante){
            var result = StatusCode(500);
            try { 
                Estudiante _Estudiante = await this.repository.Add(Estudiante);
                return CreatedAtAction(nameof(GetById), new { id = _Estudiante.Id }, _Estudiante);
            }
            catch (System.Exception) {
                return result;
            } 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetById(int id){ 
            try {
                Estudiante Estudiante = await this.repository.GetById(id);
                return Estudiante != null ? 
                    Estudiante :  NotFound(); 
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
        public async Task<ActionResult> Update(int id, [FromBody] Estudiante Estudiante) {
            var result = StatusCode(500);
            try {
                result = await this.repository.Update(id, Estudiante) ? 
                    NoContent() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }
    }
}