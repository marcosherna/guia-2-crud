using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using guia_2.models;

namespace guia_2.database
{
    public class MemoryContext {
        public List<Entity> entities;
        
        public MemoryContext() {
            entities = new List<Entity>();  
        }

        public List<TEntity> Get<TEntity>() where TEntity : Entity {
            return entities.FindAll(
                entity => entity.GetType() == typeof(TEntity)  
            ).Cast<TEntity>().ToList();
        } 

        public int Delete<TEntity>(string id) where TEntity : Entity {
            int result = -1;
            try {
                result = this.entities.FindIndex(_entity => _entity.Id == id && 
                    _entity.GetType() == typeof(TEntity));
                if(result >= 0){
                    this.entities.RemoveAt(result);
                }
            }
            catch (System.Exception) {}
            return result;
        }

        public int Update<TEntity>(string id, TEntity entity) where TEntity : Entity {
            int result = -1;
            try {
                result = this.entities.FindIndex( _entity => _entity.Id == id &&
                    _entity.GetType() == typeof(TEntity));

                if (result >= 0){
                    this.entities[result] = entity;
                    this.entities[result].Id = id;
                }
            }
            catch (System.Exception) {}
            return result;
        }
    }
}