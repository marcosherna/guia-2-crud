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
        public async Task<ActionResult<List<Materia>>> Get(){
            return  await this.repository.Get();
        }

        [HttpPost]
        public async Task<ActionResult<Materia>> Add([FromBody] Materia materia){
            var result = StatusCode(500);
            try { 
                Materia _materia = await this.repository.Add(materia);
                return CreatedAtAction(nameof(GetById), new { id = _materia.Id }, _materia);
            }
            catch (System.Exception) {
                return result;
            } 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetById(int id){ 
            try {
                Materia materia = await this.repository.GetById(id);
                return materia != null ? 
                    materia :  NotFound(); 
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
        public async Task<ActionResult> Update(int id, [FromBody] Materia materia) {
            var result = StatusCode(500);
            try {
                result = await this.repository.Update(id, materia) ? 
                    NoContent() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }
    }
}