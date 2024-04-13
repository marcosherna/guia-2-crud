using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using guia_2.models;

namespace guia_2.repositories
{
    public class ProfesorRepository : BaseRepository<Profesor>  {
        public ProfesorRepository(DbMemoryContext context) 
            : base (context) {
        }
    }
}