using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guia_2.interfaces
{
    public interface IRepository<T> {
        public bool Add(T entity);
        public bool Update(string id, T entity);
        public bool Delete(string id);
        public List<T> Get();
        public T GetById(string id);
    }
}