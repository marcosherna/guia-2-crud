using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace guia_2.models
{
    public class DbMemoryContext : DbContext {
        
        public DbMemoryContext(DbContextOptions<DbMemoryContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.Entity<Profesor>().HasData(
                new Profesor { Id = 1, Nombre = "Profesor 1", Apellido = "Apellido 1" },
                new Profesor { Id = 2, Nombre = "Profesor 2", Apellido = "Apellido 2" },
                new Profesor { Id = 3, Nombre = "Profesor 3", Apellido = "Apellido 3" }
            );

            modelBuilder.Entity<Materia>().HasData(
                new Materia { Id = 1, Nombre = "Materia 1" },
                new Materia { Id = 2, Nombre = "Materia 2" },
                new Materia { Id = 3, Nombre = "Materia 3" }
            );

            modelBuilder.Entity<Grupo>().HasData(
                new Grupo { Id = 1, IdProfesor = 1, IdMateria = 1 },
                new Grupo { Id = 2, IdProfesor = 2, IdMateria = 2 },
                new Grupo { Id = 3, IdProfesor = 3, IdMateria = 3 }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseInMemoryDatabase("DbMemory"); 
        }
        public DbSet<Grupo> grupos { get; set; }
        public DbSet<Profesor> profesores { get; set; }        
        public DbSet<Materia> materias { get; set; }
    }
}