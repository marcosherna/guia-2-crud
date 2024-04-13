using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using guia_2.models;
using Microsoft.EntityFrameworkCore;

namespace guia_2.repositories
{
    public class CarreraRepository : BaseRepository<Carrera> {
        public CarreraRepository(DbMemoryContext context) 
            : base(context) {
        }
    }
}