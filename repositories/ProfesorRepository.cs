using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using guia_2.models;
using Microsoft.EntityFrameworkCore;

namespace guia_2.repositories
{
    public class ProfesorRepository : BaseRepository<Profesor>  {
        public ProfesorRepository(DbContext context) 
            : base (context) {
        }
    }
}