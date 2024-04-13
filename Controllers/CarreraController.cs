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
    public class CarreraController : ControllerBase
    {
        private readonly IRepository<Carrera> repository;

        public CarreraController(IRepository<Carrera> repository) {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Carrera>>> Get(){
            return  await this.repository.Get();
        }

        [HttpPost]
        public async Task<ActionResult<Carrera>> Add([FromBody] Carrera Carrera){
            var result = StatusCode(500);
            try { 
                Carrera _Carrera = await this.repository.Add(Carrera);
                return CreatedAtAction(nameof(GetById), new { id = _Carrera.Id }, _Carrera);
            }
            catch (System.Exception) {
                return result;
            } 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carrera>> GetById(int id){ 
            try {
                Carrera Carrera = await this.repository.GetById(id);
                return Carrera != null ? 
                    Carrera :  NotFound(); 
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
        public async Task<ActionResult> Update(int id, [FromBody] Carrera Carrera) {
            var result = StatusCode(500);
            try {
                result = await this.repository.Update(id, Carrera) ? 
                    NoContent() :  BadRequest(); 
            }
            catch (System.Exception) {}
            return result;
        }
    }
}