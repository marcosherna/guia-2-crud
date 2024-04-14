using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using guia_2.models;
using Microsoft.EntityFrameworkCore;

namespace guia_2.database
{
    public class MysqlContext: DbContext {
        private readonly IConfiguration configuration;
        public MysqlContext(DbContextOptions<MysqlContext> options, IConfiguration configuration) 
            : base(options) {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(this.configuration.GetConnectionString("DefaultConnection"), serverVersion : ServerVersion.AutoDetect(this.configuration.GetConnectionString("DefaultConnection")));
        }

        public DbSet<Materia> Materias { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Grupo> Grupos { get; set; }

        
    }
}