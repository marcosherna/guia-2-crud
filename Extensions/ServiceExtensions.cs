using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using guia_2.interfaces;
using guia_2.models;
using guia_2.repositories;

namespace guia_2.Extensions
{
    public static class ServiceExtensions{
        public static void ConfigureRepositories(this IServiceCollection services) { 
            services.AddScoped<IRepository<Materia> ,MateriaRepository>();
            services.AddScoped<IRepository<Profesor>,ProfesorRepository>();
            services.AddScoped<IRepository<Grupo>,GrupoRepository>();
            services.AddScoped<IRepository<Estudiante>,EstudianteRepository>();
            services.AddScoped<IRepository<Carrera>,CarreraRepository>();
        }
    }
}