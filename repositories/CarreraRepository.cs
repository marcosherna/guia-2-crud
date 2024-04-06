using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using guia_2.database;
using guia_2.models;

namespace guia_2.repositories
{
    public class CarreraRepository : MemoryBaseRepository<Carrera>
    {
        public CarreraRepository(MemoryContext context) 
            : base(context) {
        }
    }
}