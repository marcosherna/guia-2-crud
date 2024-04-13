using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using guia_2.models;

namespace guia_2.repositories
{
    public class MateriaRepository : BaseRepository<Materia> {
        public MateriaRepository(DbMemoryContext context) 
            : base (context) {

        }
    }
}