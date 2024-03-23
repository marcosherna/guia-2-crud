using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using guia_2.interfaces;
using guia_2.models;

namespace guia_2.repositories
{
    public class MemoryRepository<TEntity> : IRepository<TEntity> where TEntity : Entity, new() {
        private static readonly List<TEntity> memory = new List<TEntity>();
        public bool Add(TEntity entity)  {
            bool result = false;

            try {
                if(entity.GenerateId()){
                    memory.Add(entity);
                    result = true;
                }
            }
            catch (System.Exception) {}
            return result;
        }

        public bool Delete(string id) {
            bool result = false;

            try {
                int index = memory.FindIndex( entity => entity.Id == id);
                if(index >= 0) {
                    memory.RemoveAt(index);
                    result = true;
                }
            }
            catch (System.Exception) {}
            return result;
        }

        public List<TEntity> Get() {
            return memory;
        }

        public TEntity GetById(string id) {
            return memory.FirstOrDefault(entity => entity.Id == id);
        }

        public bool Update(string id, TEntity entity) {
            bool result = false;

            try {
                int index = memory.FindIndex( entity => entity.Id == id);
                if(index >= 0) {
                    memory[index] = entity;
                    memory[index].Id = id;
                    result = true;
                }
            }
            catch (System.Exception) {}
            return result;
        }
    }
}