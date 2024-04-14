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
            this.repository = repository ;
        }

        [HttpGet]
        public async Task<ActionResult<List<Grupo>>> Get(){
            return  await this.repository.Get();
        }

        [HttpPost]
        public async Task<ActionResult<Grupo>> Add([FromBody] Grupo Grupo){
            var result = StatusCode(500);
            try { 
                Grupo _Grupo = await this.repository.Add(Grupo);
                return CreatedAtAction(nameof(GetById), new { id = _Grupo.Id }, _Grupo);
            }
            catch (System.Exception) {
                return result;
            } 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo>> GetById(int id){ 
            try {
                Grupo Grupo = await this.repository.GetById(id);
                return Grupo != null ? 
                    Grupo :  NotFound(); 
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
        public async Task<ActionResult> Update(int id, [FromBody] Grupo Grupo) {
            var result = StatusCode(500);
            try {
                result = await this.repository.Update(id, Grupo) ? 
                    NoContent() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }
    }
}