using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks; 
using guia_2.models;

namespace guia_2.repositories
{
    public class GrupoRepository : BaseRepository<Grupo> {
        public GrupoRepository(DbMemoryContext context) 
            : base(context) { 
        }

    }
}