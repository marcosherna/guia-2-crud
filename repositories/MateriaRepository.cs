using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using guia_2.database;
using guia_2.models;

namespace guia_2.repositories
{
    public class MateriaRepository : MemoryBaseRepository<Materia> {
        public MateriaRepository(MemoryContext context) 
            : base (context) {

        }
    }
}