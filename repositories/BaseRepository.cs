using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using guia_2.interfaces;
using guia_2.models;
using Microsoft.EntityFrameworkCore;

namespace guia_2.repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity, new() {

        protected readonly DbContext _context;
        public BaseRepository(DbContext context) {
            _context = context;
        }

        public async Task<TEntity> Add(TEntity entity) {
            try {
                _context.Set<TEntity>().Add(entity);
                var result = await _context.SaveChangesAsync();
                if(result == 0) {
                    throw new Exception("No se pudo guardar el registro");
                }
                return entity;
            } catch (System.Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int id) {
            try {
                var entity = _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
                if(entity == null) {
                    throw new Exception("No se encontro el registro");
                }
                _context.Set<TEntity>().Remove(entity);
                var result = await _context.SaveChangesAsync();
                return result != 0;
            } catch (System.Exception exc) {
                throw new Exception(exc.Message);
                
            } 
        }

        public async Task<List<TEntity>> Get() {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id) 
        {
            try  {
                return await _context.Set<TEntity>()
                    .FirstOrDefaultAsync(x => x.Id == id) ?? null!;
            } catch (System.Exception exc)  {
                throw new Exception(exc.Message);
            }
        }

        public async Task<bool> Update(int id, TEntity entity) {
            try {
                entity.Id = id;
                _context.Set<TEntity>().Update(entity);
                var result = await _context.SaveChangesAsync();
                
                if(result == 0) {
                    throw new Exception("No se pudo actualizar el registro");
                }
                return result > 0 ;
            } catch (System.Exception exc)  {
                throw new Exception(exc.Message);
            }
        }
    }
}