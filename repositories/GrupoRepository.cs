using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks; 
using guia_2.models;
using Microsoft.EntityFrameworkCore;

namespace guia_2.repositories
{
    public class GrupoRepository : BaseRepository<Grupo> {
        public GrupoRepository(DbContext context) 
            : base(context) { 
        }

    }
}