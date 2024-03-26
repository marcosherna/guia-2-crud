using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using guia_2.database;
using guia_2.interfaces;
using guia_2.models;

namespace guia_2.repositories
{
    public class MemoryBaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity, new() {

        protected MemoryContext context;

        public MemoryBaseRepository(MemoryContext context) {
            this.context = context;
        }

        public virtual bool Add(TEntity entity) {
            bool result = false;

            try {
                if(entity.GenerateId()){
                    context.entities.Add(entity);
                    result = true;
                }
            }
            catch (System.Exception) {}
            return result;
        }

        public virtual bool Delete(string id) {
            bool result = false;

            try {
                 result = this.context.Delete<TEntity>(id) >= 0;
            }
            catch (System.Exception) {}
            return result;
        }

        public virtual List<TEntity> Get() {
            return  this.context.Get<TEntity>();
        }

        public virtual TEntity GetById(string id) {
            return this.context.Get<TEntity>()
                .FirstOrDefault( entity => entity.Id == id);
        }

        public virtual bool Update(string id, TEntity entity) {
            bool result = false;
            try {
                result = this.context.Update<TEntity>(id, entity) >= 0;
            } catch (System.Exception) {}
            return result;
        }
    }
}