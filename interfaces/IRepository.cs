using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guia_2.interfaces
{
    public interface IRepository<T> {
        public Task<T> Add(T entity);
        public Task<bool> Update(int id, T entity);
        public Task<bool> Delete(int id);
        public Task<List<T>> Get();
        public Task<T> GetById(int id);
    }
}